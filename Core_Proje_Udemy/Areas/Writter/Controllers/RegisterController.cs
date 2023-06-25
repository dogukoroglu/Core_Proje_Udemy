using Core_Proje_Udemy.Areas.Writter.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje_Udemy.Areas.Writter.Controllers
{
    [AllowAnonymous]
    [Area("Writter")]
    [Route("Writter/[controller]/[action]")]

    public class RegisterController : Controller
    {
        private readonly UserManager<WritterUser> _userManager;

        public RegisterController(UserManager<WritterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel userRegisterViewModel)
        {
            WritterUser writterUser = new WritterUser()
            {
                Name = userRegisterViewModel.Name,
                Surname = userRegisterViewModel.Surname,
                UserName = userRegisterViewModel.UserName,
                Email = userRegisterViewModel.Mail,
                ImageUrl = userRegisterViewModel.ImageUrl
            };
            if (userRegisterViewModel.ConfirmPassword == userRegisterViewModel.Password)
            {
                var result = await _userManager.CreateAsync(writterUser, userRegisterViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
