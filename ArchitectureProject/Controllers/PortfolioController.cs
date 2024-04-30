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
		public ActionResult APortfolioList()
		{
			var portfolioList = dbEntities.Portfolio.OrderByDescending(Z => Z.DatePortfolio).ToList();
			return View(portfolioList);
		}
		[HttpGet]
		public ActionResult APortfolioUpdate(int id)
		{
			var values = dbEntities.Portfolio.ToList().Find(x => x.PortfolioID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult APortfolioUpdate(Portfolio model)
		{
			var values = dbEntities.Portfolio.ToList().Find(x => x.PortfolioID == model.PortfolioID);
			values.Title = model.Title;
			values.Image = model.Image;
			values.CustomerSupport = model.CustomerSupport;
			values.ProjectType = model.ProjectType;
			values.Clients = model.Clients;
			values.Location = model.Location;
			values.Content = model.Content;
			dbEntities.SaveChanges();
			return RedirectToAction("APortfolioList");
		}
	}
}