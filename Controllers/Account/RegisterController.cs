using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.Account
{
    public class RegisterController : Controller
    {
        dbBestEA db = new dbBestEA();
        [HttpPost]
        public ActionResult Register(Member mb)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Index", "Home");
            }

            var member = db.Member
                .Where(m => m.Email == mb.Email)
                .FirstOrDefault();

            if (member == null)
            {
                TempData["RegisterDone"] = "ok";
                db.Member.Add(mb);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "此帳號己有人使用，註冊失敗";
            return RedirectToAction("Index", "Home");
        }
    }
}