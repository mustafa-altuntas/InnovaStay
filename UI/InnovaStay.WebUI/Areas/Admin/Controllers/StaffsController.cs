using Microsoft.AspNetCore.Mvc;

namespace InnovaStay.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
