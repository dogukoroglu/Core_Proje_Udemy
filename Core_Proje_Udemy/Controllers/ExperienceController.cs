﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Controllers
{
	public class ExperienceController : Controller
	{
		ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
		public IActionResult Index()
		{
			var values = experienceManager.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddExperience()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddExperience(Experience experience)
		{
			experienceManager.TAdd(experience);
			return RedirectToAction("Index");
		}

		public IActionResult DeleteExperience(int id)
		{
			var value = experienceManager.TGetByID(id);
			experienceManager.TDelete(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateExperience(int id)
		{
			var values = experienceManager.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult UpdateExperience(Experience experience)
		{
			experienceManager.TUpdate(experience);
			return RedirectToAction("Index");
		}
	}
}
