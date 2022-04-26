using CaloriesCount.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
    public class DiaryEntry
    {

        CaloriesCountContext db = new CaloriesCountContext();

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
        [Display(Name = "Quantity in grams")]
        public decimal Quantity { get; set; }

        // Calculated Property
        [Display(Name = "Total Calories")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalCalories 
        {
            get { return db.Foods.Find(FoodId).Calories / 100 * Quantity;  }
            private set { }
        }

        // Navigational Property

        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}