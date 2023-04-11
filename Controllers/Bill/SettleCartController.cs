using BestEA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestEA.Controllers.Bill
{
    public class SettleCartController : Controller
    {
        dbBestEA db = new dbBestEA();

        public ActionResult SettleCart(decimal total)
        {
            string Email = (Session["Member"] as Member).Email;
            string guid = Guid.NewGuid().ToString();

            var cartlist = db.Cart
                .Where(m => m.Sure == "否" && m.Email == Email)
                .ToList();

            foreach (var item in cartlist)
            {
                item.OrderGuid = guid;
                item.Sure = "是";
            }

            Order order = new Order();
            order.OrderGuid = guid;
            order.Email = Email;
            order.OrderDate = DateTime.Now;
            order.Total = total;

            db.Order.Add(order);
            db.SaveChanges();

            return RedirectToAction("UserDashboard", "UserDashboard");
        }
    }
}