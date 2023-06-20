using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje_Udemy.Areas.Writter.ViewComponents
{
	public class NavbarUserProfile : ViewComponent
	{
		private readonly UserManager<WritterUser> _userManager;

		public NavbarUserProfile(UserManager<WritterUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.userImage = user.ImageUrl;
			return View();
		}
	}
}
