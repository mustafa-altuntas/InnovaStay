using System.ComponentModel.DataAnnotations;

namespace InnovaStay.WebUI.Models.User
{
    public class LoginUserVM
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Password { get; set; }
    }
}
