using Login_abd_Registration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Login_abd_Registration.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //public ActionResult Index()
        //{
        //    using(MyDbContext db = new MyDbContext())
        //    {
        //        return View(db.Registrations.ToList());
        //    }
        //}

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(registration account)
        {
            if (ModelState.IsValid)
            {
                using(MyDbContext db = new MyDbContext())
                {
                    db.Registrations.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.message = account.FirstName + " " + account.LastName + " Successfully Created";
            }
            return View();
        }

        //login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(registration user)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var usr = db.Registrations.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserID"] = usr.LoginId;
                    Session["UserName"] = usr.Username;
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "UserName or password is Wrong!!!");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
    }
}