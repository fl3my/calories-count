using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaloriesCount.ViewModels
{
    public class BaseCaloriesViewModel
    {
        public int UserCaloriesTotal { get; set; }
        public int UserCaloriesGoal { get; set; }
        public int UserCaloriesPercent {get; set;}
    }
}