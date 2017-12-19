using Datalayer;
using Dating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dating.Controllers
{
    public class EditAccountController : Controller
    {
        // GET: EditAccount
        public ActionResult EditAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditMail(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.Email = edit.mailen.Email;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }

        public ActionResult EditPassword(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.Password = edit.Password.Password;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }

        [HttpPost]
        public ActionResult EditAbout(editwrapper edit)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var id = int.Parse(Session["UserID"].ToString());
                    var usr = db.Users.Single(u => u.Id == id);
                    usr.About = edit.About.About;

                    db.SaveChanges();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong, please try again.");
                return View("EditAccount");
            }
            return RedirectToAction("EditAccount");
        }
    }
}