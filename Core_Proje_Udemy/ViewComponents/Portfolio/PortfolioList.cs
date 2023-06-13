using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.ViewComponents.Portfolio
{
	public class PortfolioList : ViewComponent
	{
		PortfolioManager portfolioManager = new PortfolioManager(new EfPortfoiloDal());
		public IViewComponentResult Invoke()
		{
			var values = portfolioManager.TGetList();
			return View(values);
		}
	}
}
