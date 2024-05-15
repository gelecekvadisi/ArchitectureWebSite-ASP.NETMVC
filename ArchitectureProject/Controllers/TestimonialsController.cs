using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class TestimonialsController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult ATestimonialsList()
		{
			var values = dbEntities.Testimonials.OrderByDescending(z => z.DateTestimonial).ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult ANewTestimonial()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewTestimonial(Testimonials testimonials)
		{
			testimonials.DateTestimonial = DateTime.Now;
			testimonials.Status = true;
			dbEntities.Testimonials.Add(testimonials);
			dbEntities.SaveChanges();
			return RedirectToAction("ATestimonialsList");
		}
		[HttpGet]
		public ActionResult AUpdateTestimonial(int id)
		{
			var values = dbEntities.Testimonials.ToList().Find(x => x.TestimonialsID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult AUpdateTestimonial(Testimonials testimonials)
		{
			var values = dbEntities.Testimonials.ToList().Find(x => x.TestimonialsID == testimonials.TestimonialsID);
			values.Name = testimonials.Name;
			values.Location = testimonials.Location;
			values.Comment = testimonials.Comment;
			dbEntities.SaveChanges();
			return RedirectToAction("ATestimonialsList");
		}
		public ActionResult ADeleteTestimonial(int id)
		{
			var testimonialsValues = dbEntities.Testimonials.ToList().Find(x => x.TestimonialsID == id);
			dbEntities.Testimonials.Remove(testimonialsValues);
			dbEntities.SaveChanges();
			return RedirectToAction("ATestimonialsList");
		}
		public ActionResult AStatusChange(int id)
		{
			var values = dbEntities.Testimonials.ToList().Find(x => x.TestimonialsID == id);
			values.Status = !values.Status;
			dbEntities.SaveChanges();
			return RedirectToAction("ATestimonialsList");
		}
	}
}