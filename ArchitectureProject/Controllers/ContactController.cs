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
		public ActionResult AContactList()
		{
			var values = db.Contact.OrderByDescending(x => x.DateContact).ToList();
			return View(values);
		}
		public ActionResult AContactDetail(int id)
		{
			var contactInfo = db.Contact.ToList().Where(x => x.ContactID == id).ToList();
			return View(contactInfo);
		}
		public ActionResult AContactDelete(int id)
		{
			var values = db.Contact.ToList().Find(x => x.ContactID == id);
			db.Contact.Remove(values);
			db.SaveChanges();
			return RedirectToAction("AContactList");
		}
	}
}