using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class SliderController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult ASliderList()
		{
			List<Slider> values = dbEntities.Slider.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult ASliderUpdate(int id)
		{
			var values = dbEntities.Slider.ToList().Find(x => x.SliderID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult ASliderUpdate(Slider slider)
		{
			var values = dbEntities.Slider.ToList().Find(x => x.SliderID == slider.SliderID);
			values.BigTitle = slider.BigTitle;
			values.Content = slider.Content;
			dbEntities.SaveChanges();
			return RedirectToAction("ASliderList");
		}
	}
}