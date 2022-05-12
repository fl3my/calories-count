using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaloriesCount.ViewModels
{
    // View model used to pass the calorie data from the base controller to the shared calories
    // partial view. 
    public class BaseCaloriesViewModel
    {
        public int UserCaloriesTotal { get; set; }
        public int UserCaloriesGoal { get; set; }
        public int UserCaloriesPercent {get; set;}
    }
}