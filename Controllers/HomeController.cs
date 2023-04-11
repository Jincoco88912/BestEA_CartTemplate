using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers
{
    public class HomeController : Controller
    {
        dbBestEA db = new dbBestEA();
        public ActionResult Index()
        {

            if (Session["Member"] != null){
                return View("Index", "_LayoutHomePageLogined");
            }

            return View("Index", "_LayoutHomePage");
        }
    }
}