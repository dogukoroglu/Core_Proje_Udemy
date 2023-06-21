using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje_Udemy.Areas.Writter.Controllers
{
    [Area("Writter")]
    [Route("Writter/Message")]
    public class MessageController : Controller
    {
        WritterMessageManager writterMessageManager = new WritterMessageManager(new EfWritterMessageDal());
        private readonly UserManager<WritterUser> _userManager;

        public MessageController(UserManager<WritterUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writterMessageManager.TGetListReceiverMessage(p);
            return View(messageList);
        }

        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writterMessageManager.TGetListSenderMessage(p);
            return View(messageList);
        }

        [Route("MessageDetails/{id}")]
		public IActionResult MessageDetails(int id)
		{
			WritterMessage writterMessage = writterMessageManager.TGetByID(id);
			return View(writterMessage);
		}

        [Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WritterMessage writterMessage = writterMessageManager.TGetByID(id);
            return View(writterMessage);
        }

        [Route("")]
        [Route("SendMessage")]
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [Route("")]
        [Route("SendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(WritterMessage p)
        {
            Context c = new Context();
            var userNameSurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            p.ReceiverName = userNameSurname;
            writterMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage");
        }
    }
}
