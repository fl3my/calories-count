using CaloriesCount.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
    /* Model used to add a quantity of food and type of food to the current user to 
     * be stored as a diary entry */
    public class DiaryEntry
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateAdded { get; set; }

        // Navigational Property
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Please enter a quantity total between 1 and 1000")]
        [Display(Name = "Quantity (g)")]
        public decimal Quantity { get; set; }


        [Display(Name = "Total Calories (Kcal)")]
        public decimal TotalCalories { get; set; }

        // Navigational Property

        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}