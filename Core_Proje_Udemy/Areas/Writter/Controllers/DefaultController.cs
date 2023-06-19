﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

		[HttpGet]
		public IActionResult AnnouncementDetails(int id)
		{
			var values = announcementManager.TGetByID(id);
			return View(values);
		}
	}
}
