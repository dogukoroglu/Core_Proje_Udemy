using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class FeatureStatistic : ViewComponent
	{
		Context c = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.skillCount = c.Skills.Count();
			ViewBag.unreadCount = c.Messages.Where(x=>x.Status==false).Count();
			ViewBag.readCount = c.Messages.Where(x => x.Status == false).Count();
			ViewBag.experienceCount = c.Experiences.Count();
			return View();
		}
	}
}
