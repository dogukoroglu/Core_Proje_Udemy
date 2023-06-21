using Core_Proje_Udemy.Areas.Writter.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core_Proje_Udemy.Areas.Writter.Controllers
{
    [Area("Writter")]
    [Route("Writter/[controller]/[action]")]
    public class ProfileController : Controller
    {

        private readonly UserManager<WritterUser> _userManager;

        public ProfileController(UserManager<WritterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}

//private readonly UserManager<WritterUser> _userManager;

//public ProfileController(UserManager<WritterUser> userManager)
//{
//    _userManager = userManager;
//}

//[HttpGet]
//public async Task<IActionResult> Index()
//{
//    var values = await _userManager.FindByNameAsync(User.Identity.Name);
//    UserEditViewModel model = new UserEditViewModel();
//    model.Name = values.Name;
//    model.Surname = values.Surname;
//    model.ImageUrl = values.ImageUrl;
//    return View(model);
//}

//[HttpPost]
//public async Task<IActionResult> Index(UserEditViewModel p)
//{
//    var user = await _userManager.FindByNameAsync(User.Identity.Name);
//    if (p.ImageUrl != null)
//    {
//        var resource = Directory.GetCurrentDirectory();
//        var extension = Path.GetExtension(p.Image.FileName);
//        var imagename = Guid.NewGuid() + extension;
//        var savelocation = resource + "/wwwroot/userimage/" + imagename;
//        var stream = new FileStream(savelocation, FileMode.Create);
//        await p.Image.CopyToAsync(stream);
//        user.ImageUrl = imagename;
//    }
//    user.Name = p.Name;
//    user.Surname = p.Surname;
//    var result = await _userManager.UpdateAsync(user);  
//    if(result.Succeeded)
//    {
//        return RedirectToAction("Index", "Login");
//    }
//    return View();