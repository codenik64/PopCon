using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PopsConfectionary14.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        [DataType(DataType.Currency)]
        public double CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}