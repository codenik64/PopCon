using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PopsConfectionary14.Models
{
    public class OrderDetail
    {
        [Key]
        [Display(Name = "Order Detail ID")]
        public int OrderDetailId { get; set; }
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Product ID")]
        public int ProductID{ get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }
        public virtual Product product { get; set; }
        public virtual Order Order { get; set; }
    }
}