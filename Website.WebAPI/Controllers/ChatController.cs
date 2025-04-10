using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Business.Abstract;
using Website.Dtos.Concrete.AccountDtos;
using Website.Dtos.Concrete.ChatDtos;
using Website.Dtos.Concrete.ContactDtos;
using Website.Entities.Concrete;
using Website.WebAPI.OpenAI;
namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private readonly IOpenAIService _openAIService;
        

        public ChatController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Ask([FromBody] ResultChatDto resultChatDto)
        {
            try
            {
                var response = await _openAIService.GetChatResponseAsync(resultChatDto.Question);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}