using CaloriesCount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CaloriesCount.ViewModels
{
    public class FoodIndexViewModel
    {
        // Used instead of the current model in the view
        public IPagedList<Food> Foods { get; set; }
        public string Search { get; set; }

        // Hold all items to be used in the select form in the view
        public IEnumerable<CategoryWithCount> CategoriesWithCounts { get; set; }
        public string Category { get; set; }

        // Used as the name of the select element in the view
        public string SortBy { get; set; }

        // Hold the data to populate the select element
        public Dictionary<string,string> Sorts { get; set; }

        // Return a list of select list items with generate the category names and counts
        public IEnumerable<SelectListItem> CategoryFilterItems
        {
            get
            {
                var allCategories = CategoriesWithCounts.Select(cc => new SelectListItem
                {
                    Value = cc.CategoryName,
                    Text = cc.CategoryNameWithCount
                });

                return allCategories;
            }
        }
    }

    // Class used to store category name and number of products
    public class CategoryWithCount
    {
        public int FoodCount { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameWithCount { 
            get 
            {
                return CategoryName + " (" + FoodCount.ToString() + ")";
            }
        }
    }
}