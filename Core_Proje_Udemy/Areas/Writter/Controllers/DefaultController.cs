using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core_Proje_Udemy.Areas.Writter.Controllers
{
	[Area("Writter")]
	[Authorize]
	public class DefaultController : Controller
	{
		AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
		public IActionResult Index()
		{
			var values = announcementManager.TGetList();
			return View(values);
		}

		[Authorize(Roles = "Admin")]
		// 30..06.2023 Revizeler
		[HttpGet]
		public IActionResult AddAnnouncement()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public IActionResult AddAnnouncement(Announcement p)
		{
			p.Date = DateTime.Parse(DateTime.Now.ToString());
			announcementManager.TAdd(p);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteAnnouncement(int id)
		{
			var value = announcementManager.TGetByID(id);
			announcementManager.TDelete(value);
			return RedirectToAction("Index", "Default", new { area = "Writter" });
			//return RedirectToAction("Index");	
		}

		[HttpGet]
		public IActionResult UpdateAnnouncement(int id)
		{
			var values = announcementManager.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateAnnouncement(Announcement p)
		{
			p.Date = DateTime.Parse(DateTime.Now.ToString());
			announcementManager.TUpdate(p);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult AnnouncementDetails(int id)
		{
			var values = announcementManager.TGetByID(id);
			return View(values);
		}

   //     [HttpPost]
   //     public IActionResult AnnouncementDetails(Announcement p)
   //     {
			//p.Date = DateTime.Parse(DateTime.Now.ToString());
   //         announcementManager.TUpdate(p);
   //         return RedirectToAction("Index");
   //     }
    }
}
