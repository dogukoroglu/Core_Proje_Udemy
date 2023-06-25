using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
