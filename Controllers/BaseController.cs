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

                var userCaloriesGoal = 2000;
                
                // Bind the calorie data to the viewModel
                viewModel.UserCaloriesTotal = Convert.ToInt32(total);
                viewModel.UserCaloriesGoal = userCaloriesGoal;
                viewModel.UserCaloriesPercent = Convert.ToInt32((total / userCaloriesGoal) * 100);

                return PartialView("_CaloriesPartial", viewModel);
            }
            return null;
        }
    }
}