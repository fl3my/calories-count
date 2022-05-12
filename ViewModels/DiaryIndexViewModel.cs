using CaloriesCount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaloriesCount.ViewModels
{
    // This view model is used to pass the current date and current total with a list of diary entries 
    // to the diary entry index view.
    public class DiaryIndexViewModel
    {
        public IEnumerable<DiaryEntry> DiaryEntries { get; set; }

        public string CurrentDate { get; set; }

        public decimal Total { get; set; }
    }
}