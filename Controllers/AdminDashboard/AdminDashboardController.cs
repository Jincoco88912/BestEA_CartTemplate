using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.AdminDashboard
{
    public class AdminDashboardController : Controller
    {
        dbBestEA db = new dbBestEA();
        public ActionResult AdminDashboard()
        {
            if (Session["Admin"] != null)
            {
                return View("AdminDashboard", "_LayoutAdminPage");
            }
            return View("AdminDashboard", "_LayoutAdminPage");
        }
    }
}