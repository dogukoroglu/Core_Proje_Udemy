using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Areas.Writter.Controllers
{
    [Area("Writter")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WritterUser> _signInManager;

        public LoginController(SignInManager<WritterUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
