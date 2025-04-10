using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Website.Dtos.Concrete.AccountDtos;
using Website.Dtos.Concrete.UserDtos;
using Website.Entities.Concrete;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7253/api/Users/GetListAll");

            string careerBridgeCookie = Request.Cookies["KariyerWeb"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", careerBridgeCookie);
            var authResponse = await client.GetAsync("https://localhost:7253/api/Users");
            if (!authResponse.IsSuccessStatusCode)
            {
                return Unauthorized("Giriş yapmadan bu sayfaya ulaşamazsınız...");
            }


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7253/api/Users?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return Ok("Başarıyla silindi");
                return View();// Silme başarılıysa ana listeye yönlendirme yap
            }
            return Ok("Başarısız");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterDto registerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(registerDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7253/api/Auth/Register", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Users");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
  
            var responseMessage = await client.GetAsync($"https://localhost:7253/api/Users{id}");

            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Update", "Users");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(DenemeDto denemeDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(denemeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7253/api/Users", stringContent);


            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Users");
            }
            return View();
        }
    }
}

