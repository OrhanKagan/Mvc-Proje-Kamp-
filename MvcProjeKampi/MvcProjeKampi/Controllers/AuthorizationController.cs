using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager cm = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var adminvalue = cm.GetList();
            return View(adminvalue);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            cm.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            cm.AdminUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult PasifYap(int id)
        {
            var bul = cm.GetByID(id);
            cm.AdminStatus(bul);
            return RedirectToAction("Index");
        }
    }
}