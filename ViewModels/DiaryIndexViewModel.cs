using CaloriesCount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaloriesCount.ViewModels
{
    public class DiaryIndexViewModel
    {
        public IEnumerable<DiaryEntry> DiaryEntries { get; set; }

        public string CurrentDate { get; set; }

        public decimal Total { get; set; }
    }
}