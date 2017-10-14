using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PopsConfectionary14.Models;

namespace PopsConfectionary14.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}