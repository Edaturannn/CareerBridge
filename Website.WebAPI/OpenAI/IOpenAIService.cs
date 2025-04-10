using System;
using Website.Entities.Concrete;

namespace Website.WebAPI.OpenAI
{
    public interface IOpenAIService
    {
        Task<string> GetChatResponseAsync(string prompt);
    }
}

