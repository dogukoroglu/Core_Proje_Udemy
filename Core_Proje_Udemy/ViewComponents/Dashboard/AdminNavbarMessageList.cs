using BusinessLayer.Concrete;
using Core_Proje_Udemy.Areas.Writter.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Udemy.ViewComponents.Dashboard
{
	public class AdminNavbarMessageList : ViewComponent
	{
		//WritterMessageManager writterMessageManager = new WritterMessageManager(new EfWritterMessageDal());
		public IViewComponentResult Invoke()
		{
			//string p = "admin@gmail.com";
			//var values = writterMessageManager.TGetListReceiverMessage(p).OrderByDescending(x=>x.WritterMessageID).Take(3).ToList();
			//return View(values);

			//Context c = new Context();
			//var filter = "admin@gmail.com";
			//var values = (from x in c.Users
			//			join y in c.WritterMessages
			//			on x.Email equals y.Sender
			//			where y.ReceiverName == filter
			//			select new WritterMessageImageUrl
			//			{
			//				ImageUrl = x.ImageUrl,
			//				Date = y.Date,
			//				SenderName = y.SenderName,
			//				MessageContent = y.MessageContent,
			//				Id = y.WritterMessageID
			//			}).OrderByDescending(x => x.Id).Take(3).ToList();
			//return View(values);

			Context context = new Context();
			var filter = "admin@gmail.com";
			var list = (from x in context.Users
						join y in context.WritterMessages
						on x.Email equals y.Sender
						where y.Receiver == filter
						select new WritterMessageImageUrl
						{
							ImageUrl =x.ImageUrl,
							Date = y.Date,
							SenderName = y.SenderName,
							MessageContent = y.MessageContent,
							Id = y.WritterMessageID
						}).OrderByDescending(x => x.Id).Take(3).ToList();
			return View(list);
		}
	}
}

//707a7938 - b156 - 48b8 - 934d - b2565ae9827e.jpg