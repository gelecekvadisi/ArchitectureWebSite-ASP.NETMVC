using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	[AllowAnonymous]
	public class AnaLayoutController : Controller
    {
        ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult MenubarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            var values = dbEntities.SiteSettings.ToList();
            return PartialView(values);
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScrollUpPartial()
        {
            return PartialView();
        }
        public PartialViewResult PlaceholderPartial()
        {
            return PartialView();
        }
    }
}