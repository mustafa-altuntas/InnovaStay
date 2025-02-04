using System.ComponentModel.DataAnnotations;

namespace InnovaStay.WebUI.Models.Service
{
    public class CreateServiceVM
    {
        [Display(Name ="Service icon url/class")]
        public string ServiceIcon { get; set; }
        [Display(Name ="Başlık")]
        public string Title { get; set; }
        [Display(Name ="Açıklama")]
        public string Description { get; set; }
    }
}
