using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler Listesi";
            ViewBag.v2 = "Hizmetlerim";
            ViewBag.v3 = "Hizmetler Listesi";
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
			ViewBag.v1 = "Yeni Hizmet Ekleme Sayfası";
			ViewBag.v2 = "Hizmetlerim";
			ViewBag.v3 = "Yeni Hizmet Ekleme Sayfası";
			return View();
        }

		[HttpPost]
		public IActionResult AddService(Service service)
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
			ViewBag.v1 = "Hizmet Düzenleme Sayfası";
			ViewBag.v2 = "Hizmetlerim";
			ViewBag.v3 = "Hizmet Düzenleme Sayfası";
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
