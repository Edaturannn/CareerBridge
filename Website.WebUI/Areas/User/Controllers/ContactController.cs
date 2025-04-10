using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Website.Dtos.Concrete.ContactDtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Website.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(IHttpClientFactory httpClientFactory)
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
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7253/api/Contacts", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            return Ok("Hatalı");   
        }
    }
}

