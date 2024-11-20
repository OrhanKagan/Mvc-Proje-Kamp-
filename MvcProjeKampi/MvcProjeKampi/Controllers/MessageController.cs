using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["AdminUserName"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }

        public ActionResult ReadInbox()
        {
            string p = (string)Session["AdminUserName"];
            var messagelist = mm.GetListReadInbox(p);
            return View(messagelist);
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminUserName"];
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult MessageTrash()
        {
            string p = (string)Session["AdminUserName"];
            var messagelist = mm.GetListTrash(p);
            return View(messagelist);
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = mm.GetByID(id);
            values.MessageStatus = false;
            mm.MessageUpdate(values);
            return RedirectToAction("MessageTrash");
        }

        public ActionResult MessageDrafts()
        {
            string p = (string)Session["AdminUserName"];
            var messagelist = mm.DraftsList(p);
            return View(messagelist);
        }

        public ActionResult MessageReading(int id)
        {
            var values = mm.GetByID(id);
            values.ReadStatus = true;
            mm.MessageUpdate(values);
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageSendboxSave(int id)
        {
            var values = mm.GetByID(id);
            values.DarftsStatus = false;
            mm.MessageUpdate(values);
            return RedirectToAction("Sendbox");
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["AdminUserName"];
            var a = mm.GetListInbox(p).Count();
            var b = mm.GetListSendbox(p).Count();
            var c = mm.GetListReadInbox(p).Count();
            ViewBag.value1 = a;
            ViewBag.value2 = b;
            ViewBag.value3 = c;
            return PartialView();
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p, string button)
        {
            string sender = (string)Session["AdminUserName"];
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                if (button == "add")
                {
                    p.SenderMail = sender;
                    mm.MessageAdd(p);
                    return RedirectToAction("Sendbox");
                }

                else if (button == "draft")
                {
                    p.SenderMail = sender;
                    mm.DraftsMessageAdd(p);
                    return RedirectToAction("MessageDrafts");
                }
                else if (button == "cancel")
                {
                    return RedirectToAction("Inbox");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}