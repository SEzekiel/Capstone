//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        public int employeeID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string fname { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string lname { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string position { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string office { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Nullable<int> age { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Nullable<int> salary { get; set; }
    }
}
