using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PopsConfectionary14.Models
{
    public partial class Order
    {
        [Key]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        public string Username { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public decimal DeliveryCost { get; set; }
        public string Email { get; set; }
        [Display(Name = "Credit Card Holder")]
        [Required]
        public string CreditCarholder { get; set; }
        [Required]
        [Display(Name = "Expiry Date")]
        public string expDate { get; set; }
        [Required]
        [Display(Name = "Credit Card Number")]
        public string CreditcardNo { get; set; }
        [Required]
        [Display(Name = "CVV Number")]
        public string CVV { get; set; }
        public decimal Total { get; set; }


 
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}