using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Website.WebUI.Areas.User.Models;
using Website.Entities.Concrete;
using System.Text;
using Website.Dtos.Concrete.AccountDtos;

namespace Website.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            string token = Request.Cookies["KariyerWeb"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Kullanıcıyı getir
            var authResponse = await client.GetAsync("https://localhost:7253/api/Users");
            if (!authResponse.IsSuccessStatusCode)
                return Unauthorized("Giriş yapmadan bu sayfaya ulaşamazsınız...");

            var authData = await authResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Website.Entities.Concrete.User>(authData);

            // Bölümleri getir
            var departmanResponse = await client.GetAsync("https://localhost:7253/api/Departmants/GetListAll");
            var departmanList = new List<Departmant>();
            if (departmanResponse.IsSuccessStatusCode)
            {
                var departmanJson = await departmanResponse.Content.ReadAsStringAsync();
                departmanList = JsonConvert.DeserializeObject<List<Departmant>>(departmanJson);
            }

            // Sınıfları getir
            var classResponse = await client.GetAsync("https://localhost:7253/api/Classes/GetListAll");
            var classList = new List<Class>();
            if (departmanResponse.IsSuccessStatusCode)
            {
                var classJson = await classResponse.Content.ReadAsStringAsync();
                classList = JsonConvert.DeserializeObject<List<Class>>(classJson);
            }

            var viewModel = new UserProfileViewModel
            {
                User = user,
                Departmants = departmanList,
                Classes = classList
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(DenemeDto denemeDto)
        {
            var client = _httpClientFactory.CreateClient();
            string token = Request.Cookies["KariyerWeb"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var authResponse = await client.GetAsync("https://localhost:7253/api/Users");
            if (!authResponse.IsSuccessStatusCode)
                return Unauthorized("Giriş yapmadan bu sayfaya ulaşamazsınız...");

            var authData = await authResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Website.Entities.Concrete.User>(authData);

            denemeDto.Id = user.Id;

            var jsonData = JsonConvert.SerializeObject(denemeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7253/api/Users", stringContent);

            if (!responseMessage.IsSuccessStatusCode)
                return View(); // hatalı ise aynı sayfa

            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}
