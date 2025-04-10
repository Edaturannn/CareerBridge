using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Dtos.Concrete.AccountDtos
{
	public class LoginDto
	{
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 20 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*\d).{6,}$", ErrorMessage = "Şifre en az bir rakam içermeli ve en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}

