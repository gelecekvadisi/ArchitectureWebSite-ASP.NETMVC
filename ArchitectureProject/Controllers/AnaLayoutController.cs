using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
    public class AnaLayoutController : Controller
    {
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
            return PartialView();
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