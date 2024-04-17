using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class PortfolioController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult Index()
		{
			var values = dbEntities.Portfolio.ToList();
			return View(values);
		}
		public ActionResult PortfolioDetail(int id)
		{
			List<Portfolio> values = dbEntities.Portfolio.ToList().Where(x => x.PortfolioID == id).ToList();
			return View(values);
		}
	}
}