using ArchitectureProject.Models.Entity;
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
		[AllowAnonymous]
		public ActionResult Index()
		{
			List<Team> values = dbEntities.Team.OrderByDescending(x => x.DateTeam).Where(z => z.Status == true).ToList();
			return View(values);
		}
		[AllowAnonymous]
		public ActionResult TeamDetail(int id)
		{
			var values = dbEntities.Team.ToList().Where(x => x.TeamID == id).ToList();
			return View(values);
		}
		public ActionResult ATeamList()
		{
			var values = dbEntities.Team.OrderByDescending(z => z.DateTeam).ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult ANewTeam()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewTeam(Team team)
		{
			team.DateTeam = DateTime.Now;
			team.Status = true;
			dbEntities.Team.Add(team);
			dbEntities.SaveChanges();
			return RedirectToAction("ATeamList");
		}
		[HttpGet]
		public ActionResult AUpdateTeam(int id)
		{
			var values = dbEntities.Team.ToList().Find(x => x.TeamID == id);
			return View(values);
		}
		[HttpPost]
		public ActionResult AUpdateTeam(Team team)
		{
			var values = dbEntities.Team.ToList().Find(x => x.TeamID == team.TeamID);
			values.Name = team.Name;
			values.Job = team.Job;
			values.ShortContent = team.ShortContent;
			values.Image = team.Image;
			dbEntities.SaveChanges();
			return RedirectToAction("ATeamList");
		}
		public ActionResult ADeleteTeam(int id)
		{
			var values = dbEntities.Team.ToList().Find(x => x.TeamID == id);
			dbEntities.Team.Remove(values);
			dbEntities.SaveChanges();
			return RedirectToAction("ATeamList");
		}
		public ActionResult AStatusChange(int id)
		{
			var values = dbEntities.Team.ToList().Find(x => x.TeamID == id);
			values.Status = !values.Status;
			dbEntities.SaveChanges();
			return RedirectToAction("ATeamList");
		}
	}
}