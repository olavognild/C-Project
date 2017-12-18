﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datalayer;
using Datalayer.Entities;

namespace Dating.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            using(Datacontext db = new Datacontext())
            {
                return View(db.Users.ToList());
            }
        }
        // GET: Login
        /*     public ActionResult Login()
             {
                 return View();
             }
             */
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                using (Datacontext db = new Datacontext())
                {
                    var usr = db.Users.Single(u => u.Email == user.Email && u.Password == user.Password);
                    if (usr != null)
                    {
                        Session["UserID"] = usr.Id.ToString();
                        return RedirectToAction("LoggedIn");
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Wrong email or password");
                return View("LogInView");
            }
            return View("LoggedIn");
        }

        public ActionResult Login()
        {
            if (Session["UsedID"] != null)
            {
                return View("LoggedIn");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult LoggedIn()
        {
            return View();
        }

        public ActionResult IndexLoggedOut()
        {
            Session.Abandon();
            Session.Remove("UserID");
            return View();
        }
        public ActionResult LogInView()
        {
            return View();
        }
    }
}