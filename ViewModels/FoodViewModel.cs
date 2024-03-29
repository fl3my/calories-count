﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaloriesCount.ViewModels
{
    /* Duplicated from the food model with added category, list of categories and
     * the file uploaded by the user. This view is used by the food controller for the 
     * Create action. */
    public class FoodViewModel
    {
        // Properties duplicated from the Food model
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The food name cannot be blank")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Please enter a food name between 3 and 40 characters in length")]
        [RegularExpression(@"^[a-zA-Z'-'\s]*$", ErrorMessage = "Please enter a food name made up of letters only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Calories cannot be blank")]
        [Range(1, 1000, ErrorMessage = "Please enter a calorie total between 0 and 1000")]
        [Display(Name = "Calories per 100g")]
        public int Calories { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a fat total between 0 and 1000")]
        [Display(Name = "Fat per 100g")]
        public double Fat { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a protein total between 0 and 1000")]
        [Display(Name = "Protein per 100g")]
        public double Protein { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a carbohydrate total between 0 and 1000")]
        [Display(Name = "Carbohydrates per 100g")]
        public double Carbohydrates { get; set; }

        [Range(0, 1000, ErrorMessage = "Please enter a fibre total between 0 and 1000")]
        [Display(Name = "Fibre per 100g")]
        public double Fibre { get; set; }

        [Display(Name = ("File Name"))]
        public string ImageFileName { get; set; }

        // Navigational Property
        [Display(Name = ("Category"))]
        public int CategoryId { get; set; }

        // Extra properties for the viewModel
        public SelectList CategoryList { get; set; }
        public HttpPostedFileBase file { get; set; }
    }
}