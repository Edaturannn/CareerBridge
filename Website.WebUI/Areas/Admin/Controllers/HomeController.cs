using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Website.Dtos.Concrete.UserDtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
           
            string careerBridgeCookie = Request.Cookies["KariyerWeb"];
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", careerBridgeCookie);
            var authResponse = await client.GetAsync("https://localhost:7253/api/Users");
            if (!authResponse.IsSuccessStatusCode)
            {
                return Unauthorized("Giriş yapmadan bu sayfaya ulaşamazsınız...");
            }


            var authData = await authResponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<Website.Entities.Concrete.User>(authData);
            ViewBag.UserName = user;
            ViewBag.UserID = user;

            return View();
        }
    }
}

