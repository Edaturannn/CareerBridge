using System;
using System.ComponentModel.DataAnnotations;

namespace Website.WebUI.Models.Account
{
	public class RegisterViewModel
	{
        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakamaz.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakamaz.")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Telefon alanı boş bırakamaz.")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Şifre alanı boş bırakamaz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }


        [Compare(nameof(Password), ErrorMessage = "Şifre aynı değil.")]
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakamaz.")]
        [Display(Name = "Şifre Tekrar")]
        public string PasswordConfirm { get; set; }
    }
}

