using CaloriesCount.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CaloriesCount.ViewModels;

namespace CaloriesCount.Controllers
{
    /* All other controllers inherit from this controller. This allows the users daily calories to be
     * viewed as a bar chart from all views on the webpage. */
    public class BaseController : Controller
    {
        CaloriesCountContext db = new CaloriesCountContext();

        // GET: Base
        [AllowAnonymous]
        public virtual ActionResult Calories()
        {
            // if the user is logged in
            if (User.Identity.IsAuthenticated)
            {
                BaseCaloriesViewModel viewModel = new BaseCaloriesViewModel();

                // Get user id
                string userId = User.Identity.GetUserId();

                DateTime filterDate;

                // set the filtered to the current date
                filterDate = DateTime.Now.Date;

                // Add one day to the end of the date to create a range
                DateTime filterDateEnd = filterDate.AddDays(1);

                // Return the diary entries created by the user and filtered by the current day
                var diaryEntries = db.DiaryEntries
                    .Include(d => d.User)
                    .Where(d => d.UserId == userId)
                    .Where(d => d.DateAdded > filterDate && d.DateAdded < filterDateEnd);

                var total = 0.00M;

                // if there is any entries show a total
                if (diaryEntries.Count() > 0)
                {
                    total = diaryEntries.Sum(t => t.TotalCalories);
                }

                // Get the users daily calorie limit.
                var userCaloriesGoal = db.Users.Find(userId).DailyCalories;
                
                // Bind the calorie data to the viewModel
                viewModel.UserCaloriesTotal = Convert.ToInt32(total);
                viewModel.UserCaloriesGoal = userCaloriesGoal;
                viewModel.UserCaloriesPercent = Convert.ToInt32((total / userCaloriesGoal) * 100);
                
                // Use a partial view to display the bar chart of daily user calories
                return PartialView("_CaloriesPartial", viewModel);
            }
            return null;
        }
    }
}