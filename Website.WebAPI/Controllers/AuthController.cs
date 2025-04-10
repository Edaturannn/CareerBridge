using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Business.Abstract;
using Website.Dtos.Concrete.AccountDtos;
namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;
        public AuthController(IUserService userService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Geçersiz giriş.");
            }

            bool success = await _userService.RegisterUserAsync(registerDto);
            if (success)
            {
                return Ok("Kayıt başarılı.");
            }
            return BadRequest("Kullanıcı adı zaten mevcut.");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Password hashing failed");
                return BadRequest("Geçersiz giriş.");
            }
            var values = await _userService.LoginUserAsync(loginDto);
            if (values != null)
            {
                return Ok(values);
            }
            
            return Unauthorized("Kullanıcı adı veya şifre hatalı.");
        }
    }
}

