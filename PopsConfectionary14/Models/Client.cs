using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PopsConfectionary14.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Customer ID")]
        public int CusID { get; set; }
        [Required]
        [StringLength(100 , ErrorMessage ="First Name is Allowed a maximum of a 100 Characters")]
        [Display(Name = "First Name")]
        public string Cname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Surname Name is Allowed a maximum of a 100 Characters")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Address is Allowed a maximum of a 100 Characters")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Contact Number is only  Allowed a maximum of a 10 digits")]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}