//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class employee
    {
        [Required(ErrorMessage = "Employee ID has to be filled")]
        [Range(1, 10000)]
        public int empId { get; set; }
        [Required(ErrorMessage = "Name has to be filled")]
        public string name { get; set; }
        [Required(ErrorMessage = "Username has to be filled")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password has to be filled")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Password should have minimum 6 characters")]
        public string password { get; set; }
        [Required(ErrorMessage = "Gender has to be filled")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Contact has to be filled")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact should have 10 numbers")]
        
        public string contact { get; set; }
        [Required(ErrorMessage = "Address has to be filled")]
        public string address { get; set; }
        [Required(ErrorMessage = "Specialisation has to be filled")]
        public string specialisation { get; set; }
        [Required(ErrorMessage = "Shift has to be filled")]
        public string shift { get; set; }
        [Required(ErrorMessage = "Date of Birth has to be filled")]
        public string bday { get; set; }
        [Required(ErrorMessage = "NIC has to be filled")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "NIC should have 10-12 characters")]
        public string nic { get; set; }
        [Required(ErrorMessage = "Email has to be filled")]
        [StringLength(150, MinimumLength = 7, ErrorMessage = "Please enter proper email")]

        public string email { get; set; }
    }
}
