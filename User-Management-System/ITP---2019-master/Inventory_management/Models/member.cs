//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------

namespace Inventory_management.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class member
    {
        
        public int PaymentId { get; set; }
        public string CustomerID { get; set; }
        [Required(ErrorMessage = "Memberhip has to be filled")]
        public string MemberShip { get; set; }
        [Required(ErrorMessage = "Amount has to be filled")]
        public Nullable<double> Amount { get; set; }
        [Required(ErrorMessage = "Date has to be filled")]
        public Nullable<System.DateTime> MemberShipValidateDate { get; set; }
        [Required(ErrorMessage = "Status has to be filled")]
        public string Status { get; set; }
    }
}