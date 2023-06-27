using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje_Udemy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
			return View();
        }

		[HttpPost]
		public IActionResult AddSeudrvice(Service service)
		{
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
		}

        public IActionResult DeleteService(int id)
        {
            var value = serviceManager.TGetByID(id);
            serviceManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
			var values = serviceManager.TGetByID(id);
			return View(values);
		}

        [HttpPost]
		public IActionResult UpdateService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
	}
}
