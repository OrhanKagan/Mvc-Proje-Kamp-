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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        MessageManager mm = new MessageManager(new EfMessageDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        [AllowAnonymous]
        public ActionResult HomePage()
        {
            int deger1 = mm.List().Count();
            ViewBag.messagevalue = deger1;
            int deger2 = hm.GetList().Count();
            ViewBag.headingvalue = deger2;
            int deger3 = wm.GetList().Count();
            ViewBag.writervalue = deger3;
            return View();
        }
    }
}