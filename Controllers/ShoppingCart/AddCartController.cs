using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.ShoppingCart
{
    public class AddCartController : Controller
    {
        dbBestEA db = new dbBestEA();
        public ActionResult AddCart(string PID)
        {
            string Email = (Session["Member"] as Member).Email;

            var incart = db.Cart
                .Where(m => m.PID == PID && m.Sure == "否" && m.Email == Email)
                .FirstOrDefault();

            if (incart == null)
            {
                var product = db.Product.Where(m => m.PID == PID).FirstOrDefault();
                Cart cart = new Cart();
                cart.Email = Email;
                cart.PID = product.PID;
                cart.PPrice = product.PPrice;
                cart.Amont = 1;
                cart.Sure = "否";
                db.Cart.Add(cart);
            }
            else
            {
                incart.Amont += 1;
            }
            db.SaveChanges();
            return RedirectToAction("UserDashboard", "UserDashboard");
        }
    }
}