using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class MessageList : ViewComponent
	{
		MessageManager messageManager = new MessageManager(new EfMessageDal());
		public IViewComponentResult Invoke()
		{
			var values = messageManager.TGetList().OrderByDescending(x=>x.MessageID).Take(4).ToList();
			return View(values);
		}
	}
}
