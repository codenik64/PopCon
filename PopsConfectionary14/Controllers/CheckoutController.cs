using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopsConfectionary14.Models;
using Microsoft.AspNet.Identity;
using PopsConfectionary14.LogicLayer;

namespace PopsConfectionary14.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();

      
        // GET: Checkout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var pay = new Payment();
            EmailLogic email = new EmailLogic();
            

            TryUpdateModel(order);
            try
            {
                order.DeliveryCost = 25;
                if (order.Status =="Delivery")
                {
                    order.Total = cart.GetTotal() + order.DeliveryCost;
                    order.PaymentType = "Cash on Delivery";
                }
                else if (order.Status == "Collection")
                {
                    order.Total = cart.GetTotal();
                    order.PaymentType = "Cash on Pickup";
                }
                order.Username = User.Identity.Name;
                order.Address = order.Address;
              
                order.Status = order.Status;
                order.OrderDate = DateTime.Now;
               
                order.Email = User.Identity.GetUserName();
                order.OrderDetails = order.OrderDetails;
                var list = storeDB.Clients.FirstOrDefault(x => x.Email == order.Username);
                order.FirstName = list.Cname;
                order.LastName = list.Surname;//Save Order
                email.Index(order.Email, "Welcome", "Thank you , Your Order has been successfully placed " + " " + "Your order Total is " + order.Total );
       
                storeDB.order.Add(order);
                storeDB.SaveChanges();

              
                //Process the order
                cart.CreateOrder(order);
                return RedirectToAction("Complete", new { id = order.OrderId});


            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.order.Any(o => o.OrderId == id && o.Username == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

         public PartialViewResult Pay(Payment p)
        {
            return PartialView("View",p);
        }

     

    }
}