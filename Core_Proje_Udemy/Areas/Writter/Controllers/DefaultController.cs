using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Areas.Writter.Controllers
{
	[Area("Writter")]
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
