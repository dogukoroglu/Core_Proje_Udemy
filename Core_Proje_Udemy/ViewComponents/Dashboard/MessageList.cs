using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class MessageList : ViewComponent
	{
		UserMessageManager messageManager = new UserMessageManager(new EfUserManagerDal());
		public IViewComponentResult Invoke()
		{
			var values = messageManager.TGetUserMessagesWithUser();
			return View(values);
		}
	}
}
