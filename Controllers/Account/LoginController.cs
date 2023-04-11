using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.Account
{
    public class LoginController : Controller
    {
        dbBestEA db = new dbBestEA();

        [HttpPost]
        public ActionResult Login(string Email, string Pwd)
        {

            // 管理員登入
            var admin = db.Admin.Where(m => m.AdminID == Email && m.Pwd == Pwd).FirstOrDefault();
            if (admin != null)
            {
                Session["Admin"] = admin;
                Session["AdminName"] = admin.AdminID;
                return RedirectToAction("AdminDashboard", "AdminDashboard", "_LayoutAdminPage");
            }

            // 會員登入
            var member = db.Member.Where(m => m.Email == Email && m.Pwd == Pwd).FirstOrDefault();

            if (member == null)
            {
                ViewBag.Message = "帳密錯誤，登入失敗";
                return RedirectToAction("Index", "Home");
            }

            Session["Member"] = member;
            Session["MemberName"] = member.Name;
            return RedirectToAction("Index", "Home");
        }
    }
}