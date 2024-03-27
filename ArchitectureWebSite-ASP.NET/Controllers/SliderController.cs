using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureWebSite_ASP.NET.Controllers
{
    public class SliderController : Controller
    {
        public PartialViewResult SliderIndex()
        {
            return PartialView();
        }
    }
}