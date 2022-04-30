using CaloriesCount.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

                var total = 0;

                // if there is any entries show a total
                if (diaryEntries.Count() > 0)
                {
                    total = Convert.ToInt32(diaryEntries.Sum(t => t.TotalCalories));
                }

                ViewBag.TotalCalories = total;

                return PartialView("_CaloriesPartial");
            }
            return null;
        }
    }
}