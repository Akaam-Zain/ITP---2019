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

    public partial class inventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inventory()
        {
            this.storeproducts = new HashSet<storeproduct>();
        }

        public int itemCode { get; set; }
        [Required]
        public string name { get; set; }
        [Range(0, 1000)]
        public int quantity { get; set; }
        public string type { get; set; }
        public string image { get; set; }
        public System.DateTime purchased_date { get; set; }
        [Required]
        public int supplier { get; set; }
        [Required]
        public string catergory { get; set; }

        public virtual supplier supplier1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<storeproduct> storeproducts { get; set; }
    }

    public enum type
    {

        Accessories,
        Equipments,
        Supplements

    }

    public enum catergory
    {

        Store,
        GYM

    }
}
