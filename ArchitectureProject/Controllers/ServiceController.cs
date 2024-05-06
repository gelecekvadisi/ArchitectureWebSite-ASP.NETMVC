using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ArchitectureProject.Controllers
{
	public class ServiceController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult Index()
		{
			List<Services> values = dbEntities.Services.OrderByDescending(x => x.DateService).Where(z => z.Status == true).ToList();
			return View(values);
		}
		public PartialViewResult InnerPage(string title)
		{
			ViewBag.innerTitle = title;
			return PartialView();
		}
		public ActionResult ServiceDetail(int id)
		{
			List<Services> values = dbEntities.Services.ToList().Where(x => x.ServicesID == id).ToList();
			return View(values);
		}
		public ActionResult AServiceList()
		{
			var servicesValue = dbEntities.Services.OrderByDescending(x => x.DateService).ToList();
			return View(servicesValue);
		}
		public ActionResult AStatusChangeService(int id)
		{
			Services service = dbEntities.Services.ToList().Find(x => x.ServicesID == id);
			service.Status = !service.Status;
			dbEntities.SaveChanges();
			return RedirectToAction("AServiceList");
		}
		[HttpGet]
		public ActionResult ANewService()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewService(Services services)
		{
			services.DateService = DateTime.Now;
			services.Status = true;
			dbEntities.Services.Add(services);
			dbEntities.SaveChanges();
			return RedirectToAction("AServiceList");
		}
		[HttpGet]
		public ActionResult AUpdateService(int id)
		{
			var values = dbEntities.Services.ToList().Find(x => x.ServicesID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult AUpdateService(Services services)
		{
			var values = dbEntities.Services.ToList().Find(x => x.ServicesID == services.ServicesID);
			values.Title = services.Title;
			values.ShortContent = services.ShortContent;
			values.WeTakeTime = services.WeTakeTime;
			values.CustomerSupport = services.CustomerSupport;
			values.Image = services.Image;
			values.Content = services.Content;
			values.DateService = DateTime.Now;
			values.Status = false;
			dbEntities.SaveChanges();
			return RedirectToAction("AServiceList");
		}
		public ActionResult ADeleteService(int id)
		{
			var values = dbEntities.Services.ToList().Find(x => x.ServicesID == id);
			dbEntities.Services.Remove(values);
			dbEntities.SaveChanges();
			return RedirectToAction("AServiceList");
		}
	}
}