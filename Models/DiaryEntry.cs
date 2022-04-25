using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
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

        // Navigational Property
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}