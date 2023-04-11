using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers
{
    public class OurProductController : Controller
    {
        dbBestEA db = new dbBestEA();
        public ActionResult OurProduct()
        {
            var ProductList = db.Product.ToList();

            if (Session["Member"] != null)
            {
                return View("OurProduct", "_LayoutHomePageLogined", ProductList);
            }

            return View("OurProduct","_LayoutHomePage",ProductList);
        }
    }
}