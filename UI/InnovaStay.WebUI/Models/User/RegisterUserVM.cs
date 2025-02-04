using System.ComponentModel.DataAnnotations;

namespace InnovaStay.WebUI.Models.User
{
    public class RegisterUserVM
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Email { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string ConfirmPassword { get; set; }
    }
}
