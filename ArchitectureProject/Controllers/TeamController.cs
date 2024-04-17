﻿using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class TeamController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult Index()
		{
			List<Team> values = dbEntities.Team.ToList();
			return View(values);
		}
		public ActionResult TeamDetail(int id)
		{
			var values = dbEntities.Team.ToList().Where(x => x.TeamID == id).ToList();
			return View(values);
		}
	}
}