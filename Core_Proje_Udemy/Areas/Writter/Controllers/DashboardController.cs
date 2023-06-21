using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Proje_Udemy.Areas.Writter.Controllers
{
    [Area("Writter")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WritterUser> _userManager;

        public DashboardController(UserManager<WritterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name;

            // Weather API
            string api = "da39c69b7df77e95e0841bb5912eba6c";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=mersin&mode=xml&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            // Statisctics
            Context c = new Context();
            ViewBag.incomingMessage = c.WritterMessages.Where(x=>x.Receiver == values.Email).Count();
            ViewBag.announcementCount = c.Announcements.Count();
            ViewBag.totalUserCount = c.Users.Count();
            ViewBag.totalSkillCount = c.Skills.Count();

            return View();
        }
    }
}

/*
 https://api.openweathermap.org/data/2.5/weather?q=mersin&appid=da39c69b7df77e95e0841bb5912eba6c&mode=xml&units=metric
 */