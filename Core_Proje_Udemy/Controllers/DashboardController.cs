﻿using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Dashboard";
            ViewBag.v2 = "İstatistikler";
            ViewBag.v3 = "İstatistik Sayfası";
            return View();
        }
    }
}
