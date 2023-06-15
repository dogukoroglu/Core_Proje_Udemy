using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class DashboardStatistic2 : ViewComponent
	{
		Context c = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = c.Portfolios.Where(x=>x.Status==true).Count();
			ViewBag.v2 = c.Messages.Count();
			ViewBag.v3 = c.Services.Count();
			return View();
		}
	}
}
