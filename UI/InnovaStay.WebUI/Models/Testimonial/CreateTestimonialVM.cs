using System.ComponentModel.DataAnnotations;

namespace InnovaStay.WebUI.Models.Testimonial
{
    public class CreateTestimonialVM
    {
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name="Açıklama")]
        public string Description { get; set; }
        [Display(Name="Fotoğraf Url")]
        public string Image { get; set; }
    }

}
