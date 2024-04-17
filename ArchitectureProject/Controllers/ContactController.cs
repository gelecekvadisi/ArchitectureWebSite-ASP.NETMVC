using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class ContactController : Controller
	{
		ArchitectureDbEntities db = new ArchitectureDbEntities();
		[HttpGet] // sadece veri ya da sayfa göstermek için kullanılır
		public ActionResult Index()
		{
			List<SiteSettings> values = db.SiteSettings.ToList();
			return View(values);
		}
		[HttpPost] // ekleme, çıkarma, güncelleme ve silme gibi işlemlerin yapıldığı yer yani aksiyonun alındığı yer
		public ActionResult Index(Contact contact)
		{
			contact.DateContact = DateTime.Now;// şuanki tarih saat bilgisi
			db.Contact.Add(contact);
			db.SaveChanges();
			return RedirectToAction("Index", "Default"); //farklı bir sayfaya yönlendirme işlemi
		}
	}
}