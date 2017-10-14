using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PopsConfectionary14.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }

        [Display(Name = "Staff Type")]
        public string StaffType { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "ID Number")]
        public string ID_Number { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [EmailAddress]
        [Compare("Email", ErrorMessage = "The E-mail and confirmation E-mail  do not match.")]
        [Display(Name = "Confirm E-mail")]
        public string Confirm_Email { get; set; }

        [Display(Name = "Contact Number")]
        public string Contact { get; set; }

        [Display(Name = "Address type")]
        public string Atype { get; set; }

        [Display(Name = "Residential Address")]
        public string Address { get; set; }

        [Display(Name = "Suburb")]
        public string Suburb { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        public string PC { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}