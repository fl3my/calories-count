using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaloriesCount.DAL;
using CaloriesCount.Models;
using CaloriesCount.ViewModels;
using Microsoft.AspNet.Identity;

namespace CaloriesCount.Controllers
{
    [Authorize]
    public class DiaryEntriesController : Controller
    {
        private CaloriesCountContext db = new CaloriesCountContext();

        // GET: DiaryEntries
        public ActionResult Index(string startDate)
        {
            DiaryIndexViewModel viewModel = new DiaryIndexViewModel();

            // Get user id
            string userId = User.Identity.GetUserId();

            DateTime filterDate;

            // If there is no set date
            if (string.IsNullOrEmpty(startDate))
            {
                // set the filtered to the current date
                filterDate = DateTime.Now.Date;
            } 
            else
            {
                // Convert string date to datetime object
                filterDate = DateTime.ParseExact(startDate, "yyyy-MM-dd", null);
            }

            DateTime filterDateEnd = filterDate.AddDays(1);

            // Return the diary entries created by the user
            var diaryEntries = db.DiaryEntries
                .Include(d => d.Food)
                .Include(d => d.User)
                .Where(d => d.UserId == userId)
                .Where(d => d.DateAdded > filterDate && d.DateAdded < filterDateEnd)
                .OrderByDescending(d => d.DateAdded);

            viewModel.DiaryEntries = diaryEntries.ToList();

            // Convert to format for dat input and pass in viewbag
            viewModel.CurrentDate = filterDate.ToString("yyyy-MM-dd");

            // if there is any entries show a total
            if (diaryEntries.Count() > 0)
            {
                viewModel.Total = diaryEntries.Sum(t => t.TotalCalories);
            }

            return View(viewModel);
        }

        // GET: DiaryEntries/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string userId = User.Identity.GetUserId();

            // Return a the diary entry only if it was created by the current user
            DiaryEntry diaryEntry = db.DiaryEntries
                .Include(d => d.Food)
                .Where(d => d.UserId == userId)
                .FirstOrDefault(d => d.Id == id);

            if (diaryEntry == null)
            {
                return HttpNotFound();
            }

            return View(diaryEntry);
        }

        // GET: DiaryEntries/Create
        public ActionResult Create(int? foodId)
        {
            // Set default select box item when navgiated from food menu
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", foodId);

            return View();
        }

        // POST: DiaryEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,FoodId")] DiaryEntry diaryEntry)
        {
            // Get the current Date
            diaryEntry.DateAdded = DateTime.Now;

            // Calculate the total calories
            diaryEntry.TotalCalories = (db.Foods.Find(diaryEntry.FoodId).Calories / 100) * diaryEntry.Quantity;

            // Get user Id
            diaryEntry.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.DiaryEntries.Add(diaryEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", diaryEntry.FoodId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", diaryEntry.UserId);

            return View(diaryEntry);
        }

        // GET: DiaryEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get user Id
            string userId = User.Identity.GetUserId();

            // Return a the diary entry only if it was created by the current user
            DiaryEntry diaryEntry = db.DiaryEntries
                .Where(d => d.UserId == userId)
                .FirstOrDefault(d => d.Id == id);

            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", diaryEntry.FoodId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", diaryEntry.UserId);

            return View(diaryEntry);
        }

        // POST: DiaryEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,FoodId")] DiaryEntry diaryEntry)
        {
            // Get the current Date
            diaryEntry.DateAdded = DateTime.Now;

            // Calculate the total calories
            diaryEntry.TotalCalories = (db.Foods.Find(diaryEntry.FoodId).Calories / 100) * diaryEntry.Quantity;

            // Get user Id
            diaryEntry.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.Entry(diaryEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodId = new SelectList(db.Foods, "Id", "Name", diaryEntry.FoodId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", diaryEntry.UserId);

            return View(diaryEntry);
        }

        // GET: DiaryEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get user Id
            string userId = User.Identity.GetUserId();

            // Return a the diary entry only if it was created by the current user
            DiaryEntry diaryEntry = db.DiaryEntries
                .Where(d => d.UserId == userId)
                .FirstOrDefault(d => d.Id == id);

            if (diaryEntry == null)
            {
                return HttpNotFound();
            }
            return View(diaryEntry);
        }

        // POST: DiaryEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);

            db.DiaryEntries.Remove(diaryEntry);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
