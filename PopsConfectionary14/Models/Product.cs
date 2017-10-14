using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopsConfectionary14.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int          ProductID           { get; set; }

        [Required, Display(Name = "Name")]
            public string       Name         { get; set; }

        [Required, Display(Name = "Description"), DataType(DataType.MultilineText)]
            public string       ProductDescription  { get; set; }

        [Required, Display(Name = "Price"), DataType(DataType.Currency)]
            public decimal       ProductPrice             { get; set; }

        [Display(Name = "Product Image")]
            public byte[]       Image               { get; set; }

        [Display(Name = "Image Path")]
            public string       ImageType           { get; set; }
        
        [Display(Name = "Category")]
            public int          CategoryID          { get; set; }

        [ForeignKey("CategoryID")]
            public Category     Category            { get; set; }

    }
}