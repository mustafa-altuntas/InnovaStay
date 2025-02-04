using InnovaStay.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InnovaStay.WebUI.Controllers
{
    public class HomeController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }



    }
}
