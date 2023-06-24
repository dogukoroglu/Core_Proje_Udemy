using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class AdminNavbarNotificationList:ViewComponent
	{
		AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
		public IViewComponentResult Invoke()
		{
			var values = announcementManager.TGetList().OrderByDescending(x=>x.AnnouncementID).Take(3).ToList();
			return View(values);
		}
	}
}
