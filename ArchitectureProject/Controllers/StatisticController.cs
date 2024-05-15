using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class StatisticController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult AStatisticList()
		{
			var values = dbEntities.Statistic.ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult ANewStatistic()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewStatistic(Statistic statistic)
		{
			dbEntities.Statistic.Add(statistic);
			dbEntities.SaveChanges();
			return RedirectToAction("AStatisticList");
		}
		[HttpGet]
		public ActionResult AUpdateStatistic(int id)
		{
			var values = dbEntities.Statistic.ToList().Find(x => x.StatisticID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult AUpdateStatistic(Statistic statistic)
		{
			var values = dbEntities.Statistic.ToList().Find(x => x.StatisticID == statistic.StatisticID);
			values.Title = statistic.Title;
			values.Data = statistic.Data;
			dbEntities.SaveChanges();
			return RedirectToAction("AStatisticList");
		}
		public ActionResult ADeleteStatistic(int id)
		{
			var values = dbEntities.Statistic.ToList().Find(x => x.StatisticID == id);
			dbEntities.Statistic.Remove(values);
			dbEntities.SaveChanges();
			return RedirectToAction("AStatisticList");
		}
		public ActionResult AStatusChange(int id)
		{
			var values = dbEntities.Statistic.ToList().Find(x => x.StatisticID == id);
			values.Status = !values.Status;
			dbEntities.SaveChanges();
			return RedirectToAction("AStatisticList");
		}
	}
}