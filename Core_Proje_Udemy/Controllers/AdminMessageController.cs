using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje_Udemy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminMessageController : Controller
	{
		WritterMessageManager writterMessageManager = new WritterMessageManager(new EfWritterMessageDal());

        public IActionResult AdminInbox()
		{
			string p;
			p = "admin@gmail.com";
			var values = writterMessageManager.TGetListReceiverMessage(p);
			return View(values);
		}

		public IActionResult AdminSendbox()
		{
			string p;
			p = "admin@gmail.com";
			var values = writterMessageManager.TGetListSenderMessage(p);
			return View(values);
		}

		public IActionResult AdminMessageDetails(int id)
		{
			var value = writterMessageManager.TGetByID(id);
			return View(value);
		}

		public IActionResult AdminMessageDelete(int id)
		{
			string p;
			p = "admin@gmail.com";
			var value = writterMessageManager.TGetByID(id);
			if (value.Receiver == p)
			{
				writterMessageManager.TDelete(value);
				return RedirectToAction("AdminInbox");
			}
			else
			{
				writterMessageManager.TDelete(value);
				return RedirectToAction("AdminSendbox");
			}
		}

		[HttpGet]
		public IActionResult AdminSendMessage()
		{
			Context c = new Context();
			var defaultUser = "admin@gmail.com";
			List<SelectListItem> userList = (from x in c.Users.ToList()
											 where x.Email != defaultUser
											 select new SelectListItem
											 {
												 Text = x.Name + " " + x.Surname,
												 Value = x.Email
											 }).ToList();
			ViewBag.userList = userList;
			return View();
		}

		[HttpPost]
		public IActionResult AdminSendMessage(WritterMessage p)
		{
			Context c = new Context();
			var receiverName = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
			p.Sender = "admin@gmail.com";
			p.SenderName = "Admin";
			p.Date = DateTime.Parse(DateTime.Now.ToString());
			p.ReceiverName = receiverName;
			writterMessageManager.TAdd(p);
			return RedirectToAction("AdminSendbox", "AdminMessage");
		}
	}
}
