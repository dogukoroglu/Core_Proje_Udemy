using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje_Udemy.Controllers
{
	[Authorize(Roles = "Admin")]
	public class TestimonialController : Controller
	{
		TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());
		public IActionResult Index()
		{
			var values = testimonialManager.TGetList();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddTestimonial()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddTestimonial(Testimonial testimonial)
		{
			testimonialManager.TAdd(testimonial);
			return RedirectToAction("Index", "Testimonial");
		}

		public IActionResult DeleteTestimonial(int id)
		{
			var value = testimonialManager.TGetByID(id);
			testimonialManager.TDelete(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult UpdateTestimonial(int id)
		{
			var value = testimonialManager.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateTestimonial(Testimonial testimonial)
		{
			testimonialManager.TUpdate(testimonial); 
			return RedirectToAction("Index","Testimonial");
		}
	}
}
