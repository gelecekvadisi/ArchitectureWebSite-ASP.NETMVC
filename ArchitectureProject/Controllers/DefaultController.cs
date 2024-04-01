using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Banner()
        {
            return PartialView();
        }
        public PartialViewResult AboutUs()
        {
            return PartialView();
        }
        public PartialViewResult CountEmployee()
        {
            return PartialView();
        }
        public PartialViewResult Services()
        {
            return PartialView();
        }
        public PartialViewResult Project()
        {
            return PartialView();
        }
        public PartialViewResult Features()
        {
            return PartialView();
        }
        public PartialViewResult Testimonials()
        {
            return PartialView();
        }
        public PartialViewResult Teams()
        {
            return PartialView();
        }
    }
}