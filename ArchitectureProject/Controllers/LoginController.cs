using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ArchitectureProject.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Index(Admin admin)
		{
			var info = dbEntities.Admin.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
			if (info != null)
			{
				FormsAuthentication.SetAuthCookie(info.Username, false);
				Session["Username"] = info.Username.ToString();
				return RedirectToAction("AAboutList", "About");
			}
			else
			{
				return RedirectToAction("Index","Login");
			}
		}
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			Session.Abandon();
			return RedirectToAction("Index", "Login");
		}
	}
}