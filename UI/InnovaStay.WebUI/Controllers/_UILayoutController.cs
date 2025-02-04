using Microsoft.AspNetCore.Mvc;

namespace InnovaStay.WebUI.Controllers
{
    public class _UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
 

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
 
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
    }
}
