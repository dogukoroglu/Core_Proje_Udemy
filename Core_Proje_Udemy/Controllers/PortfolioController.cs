using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Udemy.Controllers
{
	public class PortfolioController : Controller
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EfPortfoiloDal());
		public IActionResult Index()
		{
			ViewBag.v1 = "Proje Listesi";
			ViewBag.v2 = "Projelerim";
			ViewBag.v3 = "Proje Listesi";
			var values = portfolioManager.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddPortfolio()
		{
			ViewBag.v1 = "Proje Listesi";
			ViewBag.v2 = "Projelerim";
			ViewBag.v3 = "Proje Listesi";
			return View();
		}

		[HttpPost]
		public IActionResult AddPortfolio(Portfolio portfolio)
		{
			PortfolioValidator validator = new PortfolioValidator();
			ValidationResult result = validator.Validate(portfolio);
			if (result.IsValid)
			{
				portfolio.Status = false;
				portfolio.Image1 = "None";
				portfolio.Image2 = "None";
				portfolio.Image3 = "None";
				portfolio.Image4 = "None";
				portfolioManager.TAdd(portfolio);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		public IActionResult DeletePortfolio(int id)
		{
			var value = portfolioManager.TGetByID(id);
			portfolioManager.TDelete(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdatePortfolio(int id)
		{
			ViewBag.v1 = "Proje Listesi";
			ViewBag.v2 = "Projelerim";
			ViewBag.v3 = "Proje Listesi";
			var value = portfolioManager.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdatePortfolio(Portfolio portfolio)
		{
			PortfolioValidator validator = new PortfolioValidator();
			ValidationResult result = validator.Validate(portfolio);
			if (result.IsValid)
			{
				portfolioManager.TUpdate(portfolio);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		public IActionResult ChangeStatusToTrue(int id)
		{
			portfolioManager.PortfolioStatusChangeTrue(id);
			return RedirectToAction("Index");
		}

		public IActionResult ChangeStatusToFalse(int id)
		{
			portfolioManager.PortfolioStatusChangeFalse(id);
			return RedirectToAction("Index");
		}

	}
}
