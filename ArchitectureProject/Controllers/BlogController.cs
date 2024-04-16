﻿using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
    public class BlogController : Controller
    {
        ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
        public ActionResult Index()
        {
            var values = dbEntities.Blog.ToList();
            return View(values);
        }
    }
}