using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Website.Dtos.Concrete.ChatDtos;

namespace Website.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ConsultingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ConsultingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ResultChatDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7253/api/Chat", content);
            var result = await response.Content.ReadAsStringAsync();

            ViewBag.UserMessage = dto.Question;
            ViewBag.ChatResponse = result;

            return View("Index");
        }
    }
}
