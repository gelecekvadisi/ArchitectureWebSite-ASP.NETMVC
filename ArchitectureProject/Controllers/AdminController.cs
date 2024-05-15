using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class AdminController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		public ActionResult AAdminList()
		{
			var adminList = dbEntities.Admin.ToList();
			return View(adminList);
		}
		[HttpGet]
		public ActionResult ANewAdmin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewAdmin(Admin admin)
		{
			admin.Status = true;
			dbEntities.Admin.Add(admin);
			dbEntities.SaveChanges();
			return RedirectToAction("AAdminList");
		}
		[HttpGet]
		public ActionResult AUpdateAdmin(int id)
		{
			var adminValues = dbEntities.Admin.ToList().Find(x => x.AdminId == id);
			return View(adminValues);
		}
		[HttpPost]
		public ActionResult AUpdateAdmin(Admin admin)
		{
			var adminValues = dbEntities.Admin.ToList().Find(x => x.AdminId == admin.AdminId);
			adminValues.Username = admin.Username;
			adminValues.Password = admin.Password;
			dbEntities.SaveChanges();
			return RedirectToAction("AAdminList");
		}
	}
}