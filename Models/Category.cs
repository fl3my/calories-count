using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The category cannot be left blank")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Please enter a category name between 3 and 40 characters in length")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a category with a name beginning with a capital letter and made up with letters and spaces only")]
        public string Name { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}

