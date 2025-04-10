using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Website.Dtos.Concrete.AccountDtos;
namespace Website.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, string rolename)
        {
            var client = _httpClientFactory.CreateClient();
            string KariyerWeb = Request.Cookies["KariyerWeb"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", KariyerWeb);

            //Kullanıcı bilgilerini JSON olarak hazırlıyoruz.
            var loginData = new 
            {
                Username = username,
                Rolename = rolename,
                Password = password
            };
            //JSON verisini StringContent olarak hazırlıyoruz.
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            //POST isteği gönderiyoruz.
            var authResponse = await client.PostAsync("https://localhost:7253/api/Auth/Login", content);

            if (!authResponse.IsSuccessStatusCode)
            {
                return Ok("Hatalı Giriş Yaptınız!!!");
            }

            //Dönen JSON verisini deserialization yapıyoruz.
            var loginResult = await authResponse.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<LoginResultDto?>(loginResult);

            if (values == null)
            {
                return Ok("Hatalı Giriş Yaptınız!!!");
            }

            //Token'ı tarayıcıya çerez olarak ekliyoruz.
            Response.Cookies.Append("KariyerWeb", values.Token, new CookieOptions
            {
                HttpOnly = true, //XSS saldırılarına karşı koruma.
                Secure = false, //HTTPS üzerinden gönderim
                SameSite = SameSiteMode.Lax, //Çerezin sadece aynı site üzerinden çalışması
                Expires = DateTimeOffset.UtcNow.AddDays(7) //Çerezin geçerlilik süresi
            });

            //Başarılı giriş sonrası yönlendirme yapıyoruz.
            if (values.RoleName == "Admin")
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            if (values.RoleName == "User")
            {
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            return Ok("Rol Alanınız Boş Tekrar Giriniz...");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(registerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7253/api/Auth/Register", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
    }
}

