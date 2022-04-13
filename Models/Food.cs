using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The food name cannot be blank")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Please enter a food name between 3 and 40 characters in length")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Please enter a food name made up of letters only")]
        public string Name { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Calories cannot be blank")]
        [Range(1, 1000, ErrorMessage = "Please enter a calorie total between 0 and 1000")]
        [Display(Name = "Calories per 100g")]
        public int Calories { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a fat total between 0 and 1000")]
        [Display(Name = "Fat per 100g")]
        public double? Fat { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a protein total between 0 and 1000")]
        [Display(Name = "Protein per 100g")]
        public double? Protein { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a carbohydrate total between 0 and 1000")]
        [Display(Name = "Carbohydrates per 100g")]
        public double? Carbohydrates { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a fibre total between 0 and 1000")]
        [Display(Name = "Fibre per 100g")]
        public double? fibre { get; set; }

        // Navigational Property

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}