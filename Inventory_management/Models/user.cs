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
    using System.ComponentModel;
    using System.Web;

    public partial class user
    {
        public int regId { get; set; }

        [DisplayName("First Name")]
        public string fname { get; set; }
        [DisplayName("Last Name")]
        public string lname { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Password")]
        public string password_ { get; set; }
        [DisplayName("Age")]
        public int age { get; set; }
        [DisplayName("Occupation")]
        public string ocp { get; set; }
        [DisplayName("Weight")]
        public int weight_ { get; set; }
        [DisplayName("Height")]
        public double height { get; set; }
        [DisplayName("Phone")]
        public string phone { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Schedule")]
        public string shedule { get; set; }
        [DisplayName("Plan")]
        public string d_plan { get; set; }
        [DisplayName("Payment Type")]
        public string pay_type { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Image Path")]
        public string img_path { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


    }
}
