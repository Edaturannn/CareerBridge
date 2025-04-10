using System;
using System.ComponentModel.DataAnnotations;

namespace Website.WebUI.Models.Account
{
	public class ResetPasswordViewModel
	{
        [Required]
        public string Token { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string NewPassword { get; set; }
    }
}

