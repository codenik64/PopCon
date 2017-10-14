using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PopsConfectionary14.Models;

namespace PopsConfectionary14.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }

        [DataType(DataType.Currency)]
        public double CartTotal { get; set; }
    }
}