using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PopsConfectionary14.Models
{
    public class Cart
    {
        [Key]
        [Display(Name ="Record ID")]
        public int RecordId { get; set; }
        [Display(Name = "Cart ID")]
        public string CartId { get; set; }
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }
        [Display(Name = "Count")]
        public int Count { get; set; }
        [Display(Name = "Date Created")]
        public System.DateTime DateCreated { get; set; }
        public virtual Product product { get; set; }
        public bool IsComplete { get; set; }
    }
}