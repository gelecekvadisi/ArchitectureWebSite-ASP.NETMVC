using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class DesignController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult ADesignList()
		{
			var values = dbEntities.DesignAgency.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult ADesignUpdate(int id)
		{
			var values = dbEntities.DesignAgency.ToList().Find(x => x.DesignAgencyID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult ADesignUpdate(DesignAgency designAgency)
		{
			var designInfo = dbEntities.DesignAgency.ToList().Find(x => x.DesignAgencyID == designAgency.DesignAgencyID);
			designInfo.Title = designAgency.Title;
			designInfo.Content = designAgency.Content;
			designInfo.Creativity = designAgency.Creativity;
			designInfo.Management = designAgency.Management;
			designInfo.SpacePlan = designAgency.SpacePlan;
			dbEntities.SaveChanges();
			return RedirectToAction("ADesignList");
		}
	}
}