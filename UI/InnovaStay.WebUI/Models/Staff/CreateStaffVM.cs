using System.ComponentModel.DataAnnotations;

namespace InnovaStay.WebUI.Models.Staff
{
    public class CreateStaffVM
    {
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Sosyal Medya 1")]
        public string? SocialMedia1 { get; set; }
        [Display(Name = "Sosyal Medya 2")]
        public string? SocialMedia2 { get; set; }
        [Display(Name = "Sosyal Medya 3")]
        public string? SocialMedia3 { get; set; }
    }
}
