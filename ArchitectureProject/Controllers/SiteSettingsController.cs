using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class SiteSettingsController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult ASiteSettingsList()
		{
			var values = dbEntities.SiteSettings.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult ASiteSettingsUpdate(int id)
		{
			var values = dbEntities.SiteSettings.ToList().Find(x => x.SiteSettingsID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult ASiteSettingsUpdate(SiteSettings siteSettings)
		{
			var values = dbEntities.SiteSettings.ToList().Find(x => x.SiteSettingsID == siteSettings.SiteSettingsID);
			values.FacebookLink = siteSettings.FacebookLink;
			values.LinkedinLink = siteSettings.LinkedinLink;
			values.TwitterLink = siteSettings.TwitterLink;
			values.InstagramLink = siteSettings.InstagramLink;
			values.YoutubeLink = siteSettings.YoutubeLink;
			values.Address = siteSettings.Address;
			values.PhoneNumber = siteSettings.PhoneNumber;
			values.CompanyNumber = siteSettings.CompanyNumber;
			values.Email = siteSettings.Email;
			values.Map = siteSettings.Map;
			dbEntities.SaveChanges();
			return RedirectToAction("ASiteSettingsList");
		}
	}
}