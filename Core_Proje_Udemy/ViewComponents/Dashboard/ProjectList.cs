using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class ProjectList : ViewComponent
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EfPortfoiloDal());
		public IViewComponentResult Invoke()
		{
			var values = portfolioManager.TGetList();
			return View(values);
		}
	}
}
