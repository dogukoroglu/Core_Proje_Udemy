﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Controllers
{
	public class SocialMediaController : Controller
	{
		SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
		public IActionResult Index()
		{
			var values = socialMediaManager.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddSocialMedia()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddSocialMedia(SocialMedia socialMedia)
		{
			socialMedia.Status = true;
			socialMediaManager.TAdd(socialMedia);
			return RedirectToAction("Index", "SocialMedia");
		}

		public IActionResult DeleteSocialMedia(int id)
		{
			var value = socialMediaManager.TGetByID(id);
			socialMediaManager.TDelete(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateSocialMedia(int id)
		{
			var values = socialMediaManager.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
		{
			socialMediaManager.TUpdate(socialMedia);
			return RedirectToAction("Index", "SocialMedia");
		}

	}
}
