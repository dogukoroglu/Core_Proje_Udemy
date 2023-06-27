using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace Core_Proje_Udemy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class ContactController : Controller
	{
		MessageManager messageManager = new MessageManager(new EfMessageDal());
		public IActionResult Index()
		{
			var values = messageManager.TGetList().OrderByDescending(x => x.MessageID).ToList();
			return View(values);
		}

		public IActionResult DeleteMessage(int id)
		{
			var value = messageManager.TGetByID(id);
			messageManager.TDelete(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult MessageDetails(int id)
		{
			var value = messageManager.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult MessageDetails(Message message)
		{
			messageManager.TUpdate(message);
			return RedirectToAction("Index", "Contact");
		}
	}
}
