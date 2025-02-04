using InnovaStay.WebUI.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using InnovaStay.Entity.Concrete.Identities;

namespace InnovaStay.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM registerUserVM)
        {
            if (!ModelState.IsValid)
                return View(registerUserVM);

            AppUser appUser = new AppUser
            {
                FirstName = registerUserVM.FirstName,
                LastName = registerUserVM.LastName,
                Email = registerUserVM.Email,
                UserName = registerUserVM.UserName
            };

            IdentityResult identityResult = await userManager.CreateAsync(appUser, registerUserVM.Password);
            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = $"{appUser.Email} \n Kullancı kaydı başarılı.";
                return Redirect("Login");
            }

            foreach (var item in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(registerUserVM);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AppUser appUser = await userManager.FindByEmailAsync(model.Email);
            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu emal veya şifrenizi doğru girdiğinizden emin olun.");
                return View(model);
            }

            var signInResult = await signInManager.PasswordSignInAsync(appUser, model.Password, false, false);

            

            if (signInResult.Succeeded)
            {
                TempData["SuccessMessage"] = $"{appUser.Email} \n Kullancı giriş işlemi başarılı.";
                return Redirect("/");
            }
 

            return View(model);
        }
    }
}
