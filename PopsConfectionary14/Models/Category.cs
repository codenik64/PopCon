using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopsConfectionary14.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int          CategoryID          { get; set; }

        [Required, Display(Name ="Category Type")]
        public string       CategoryType        { get; set; }

        public List<Product> Products { get; set; }
    }
}