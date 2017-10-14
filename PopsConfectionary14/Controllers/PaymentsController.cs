using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PopsConfectionary14.Models;
using Microsoft.AspNet.Identity;

namespace PopsConfectionary14.Controllers
{
    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payments
        public ActionResult Index()
        {
            return View(db.Payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        
        

        // GET: Payments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PID,CreditCarholder,expDate,CreditcardNo,CVV,Status,deliveryCost,Total")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                var order = new Order();
                var cart = ShoppingCart.GetCart(this.HttpContext);
              
               
                if (payment.Status == "Delivery")
                {
                    payment.Total = cart.GetTotal() + 25;
                }
                else if (payment.Status == "Collection")
                {
                    payment.Total = cart.GetTotal();
                }
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                order.Total = cart.GetTotal();
                order.Email = User.Identity.GetUserName();
                order.OrderDetails = order.OrderDetails;
                var list = db.Clients.FirstOrDefault(x => x.Email == order.Username);
                order.FirstName = list.Cname;
                order.LastName = list.Surname;//Save Order
                db.order.Add(order);
                db.SaveChanges();


                //Process the order
                cart.CreateOrder(order);
                return RedirectToAction("Complete","Checkout", new { id = order.OrderId });


                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
              

            }

            return View(payment);
        }
       

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,CreditCarholder,expDate,CreditcardNo,CVV,Status,deliveryCost,Total")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
