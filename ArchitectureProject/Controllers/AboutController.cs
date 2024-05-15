using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class AboutController : Controller
	{
		ArchitectureDbEntities db = new ArchitectureDbEntities();
		[AllowAnonymous]
		public ActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public PartialViewResult SloganBanner()
		{
			return PartialView();
		}
		public ActionResult AAboutList()
		{
			var values = db.About.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult AAboutUpdate(int id)
		{
			var aboutInfo = db.About.ToList().Find(x => x.AboutID == id);
			return View(aboutInfo);
		}
		[HttpPost]
		public ActionResult AAboutUpdate(About about)
		{
			var aboutInfo = db.About.ToList().Find(x => x.AboutID == about.AboutID);
			aboutInfo.BigTitle = about.BigTitle;
			aboutInfo.SubTitle = about.SubTitle;
			aboutInfo.Content = about.Content;
			aboutInfo.OurGoal = about.OurGoal;
			aboutInfo.OurStory = about.OurStory;
			aboutInfo.BigImage = about.BigImage;
			aboutInfo.ShortImage = about.ShortImage;
			db.SaveChanges();
			return RedirectToAction("AAboutList");
		}
	}
}