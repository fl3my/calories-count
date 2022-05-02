using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaloriesCount.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        [RegularExpression("^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$", ErrorMessage = "Email not valid")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        [DataType(DataType.Date)]
        public DateTime MessageDate { get; set; }
    }
}