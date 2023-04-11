using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.UserDashboard
{
    public class UserDashboardController : Controller
    {
        dbBestEA db = new dbBestEA();
        public ActionResult UserDashboard()
        {
            string Email = (Session["Member"] as Member).Email;

            //CartList/////////////////////////////////////////////
            var CartList = db.Cart.Where
                (m => m.Email == Email && m.Sure == "否").ToList();
            ViewBag.CartList = CartList;

            //TempData["CartTotal"]----------
            {
                decimal total = 0;
                foreach (var product in CartList)
                {
                    decimal subtotal = product.Amont * product.PPrice;
                    total += subtotal;
                }
                TempData["CartTotal"] = total;
            }
            //OrderList////////////////////////////////////////////
            var OrderList = db.Order.Where
                (m => m.Email == Email).ToList();
            ViewBag.OrderList = OrderList;
            ///////////////////////////////////////////////////////
            return View("UserDashboard","_LayoutUserPage");
        }
    }
}