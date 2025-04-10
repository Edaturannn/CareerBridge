using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace Website.WebAPI.OpenAI
{
    public class OpenAIService : IOpenAIService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public OpenAIService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetChatResponseAsync(string prompt)
        {
            var apiKey = _configuration["OpenAI:ApiKey"];

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new { role = "user", content = prompt }
                },
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody),Encoding.UTF8,"application/json");
            var response = _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content).Result;

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            dynamic result = JsonConvert.DeserializeObject(responseBody);
            return result.choices[0].message.content.ToString();

        }
    }
}

