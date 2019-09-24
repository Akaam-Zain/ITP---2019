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
    using System.Web;

    public partial class schedule
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name has to be filled!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender has to be selected!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Category has to be filled!")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Level has to be filled!")]
        public string Level { get; set; }

        [Required(ErrorMessage = "Description has to be filled!")]
        public string Description { get; set; }

        [Range(1, 100)]
        [Required(ErrorMessage = "Days has to be filled!")]
        public int Days { get; set; }


        public string Image { get; set; }

        [Display(Name = "Morning Trainer")]
        [Required(ErrorMessage = "Trainer has to be filled!")]
        public string Morning_Trainer { get; set; }

        [Display(Name = "Evening Trainer")]
        [Required(ErrorMessage = "Trainer has to be filled!")]
        public string Evening_Trainer { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Category
    {
        Muscle_Gain,
        Weight_loss,
        Calisthenics,
        Cardio
    }

    public enum Level
    {
        Beginner,
        Intermediate,
        Advance,
        Professional
    }
}

//comment