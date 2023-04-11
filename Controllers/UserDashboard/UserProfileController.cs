using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.UserDashboard
{
    public class UserProfileController : Controller
    {
        dbBestEA db = new dbBestEA();
        public ActionResult UserProfile()
        {
            string Email = (Session["Member"] as Member).Email;
            var member = db.Member.Where
                (m => m.Email == Email).FirstOrDefault();

            return View("UserProfile", "_LayoutUserPage", member);
        }

        [HttpPost]
        public ActionResult UserProfile(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UserProfileDone"] = "ok";

                return RedirectToAction("UserProfile", "UserProfile");
            }
            return RedirectToAction("UserProfile", "UserProfile");
        }
    }
}