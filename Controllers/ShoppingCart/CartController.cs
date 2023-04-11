using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.ShoppingCart
{
    public class CartController : Controller
    {
        dbBestEA db = new dbBestEA();
        public ActionResult Cart()
        {
            string Email = (Session["Member"] as Member).Email;

            var CartList = db.Cart.Where
                (m => m.Email == Email && m.Sure == "否")
                .ToList();

            return View(CartList);
        }
    }
}