﻿using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Controllers
{
	public class FeatureController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}