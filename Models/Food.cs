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
        public string Name { get; set; }

        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        [Display(Name = "Calories per 100g")]
        public int Calories { get; set; }

        [Display(Name = "Fat per 100g")]
        public double Fat { get; set; }

        [Display(Name = "Protein per 100g")]
        public double Protein { get; set; }

        [Display(Name = "Carbohydrates per 100g")]
        public double Carbohydrates { get; set; }

        [Display(Name = "Fibre per 100g")]
        public double fibre { get; set; }

        // Navigational Property

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}