using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();		
		public ActionResult Index()
		{
			return View();
		}
		public PartialViewResult Banner()
		{
			List<Slider> sliderValues = dbEntities.Slider.ToList();
			return PartialView(sliderValues);
		}
		public PartialViewResult BannerSettingsPartial()
		{
			var values = dbEntities.SiteSettings.ToList();
			return PartialView(values);
		}
		public PartialViewResult AboutUs()
		{
			List<About> aboutValues = dbEntities.About.ToList();
			return PartialView(aboutValues);
		}
		public PartialViewResult CountEmployee()
		{
			var counterValues = dbEntities.Statistic.Where(x => x.Status == true).ToList();
			return PartialView(counterValues);
		}
		public PartialViewResult Services()
		{
			var serviceValues = dbEntities.Services.Where(x => x.Status == true).Take(5).ToList();
			return PartialView(serviceValues);
		}
		public PartialViewResult Project()
		{
			var projectValues = dbEntities.Portfolio.Where(x => x.Status == true).ToList();
			return PartialView(projectValues);
		}
		public PartialViewResult Features()
		{
			var featureValues = dbEntities.DesignAgency.ToList();
			return PartialView(featureValues);
		}
		public PartialViewResult Testimonials()
		{
			var testimonialValues = dbEntities.Testimonials.Where(x => x.Status == true).Take(5).ToList();
			return PartialView(testimonialValues);
		}
		public PartialViewResult Teams()
		{
			var teamValues = dbEntities.Team.Where(x => x.Status == true).Take(5).ToList();
			return PartialView(teamValues);
		}
		public PartialViewResult SponsorBanner()
		{
			return PartialView();
		}
		public PartialViewResult Blog()
		{
			var blogValues = dbEntities.Blog.Where(x => x.Status == true).Take(5).ToList();
			return PartialView(blogValues);
		}
	}
}