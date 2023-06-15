using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Controllers
{
    public class NewAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public PartialViewResult NewPartialSidebar()
		{
			return PartialView();
		}
	}
}
