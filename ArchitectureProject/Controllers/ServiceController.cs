using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
    public class ServiceController : Controller
    {
        ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
        public ActionResult Index()
        {
            List<Services> values = dbEntities.Services.ToList();
            return View(values);
        }
        public PartialViewResult InnerPage(string title)
        {
            ViewBag.innerTitle = title;
            return PartialView();
        }
    }
}