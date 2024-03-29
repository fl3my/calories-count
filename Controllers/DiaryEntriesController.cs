﻿using System;
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
    /* The DiaryEntriesController allows all users to Create, Edit and delete food diary entries
     * that they make. The index by default shows the user the entries for the current day but
     * this can be changed to show entries for anyother day. A Delete all action is also provided
     * which removes all entries from the database from the selected day. */
    [Authorize]
    public class DiaryEntriesController : BaseController
    {
        private CaloriesCountContext db = new CaloriesCountContext();

        // GET: DiaryEntries
        public ActionResult Index(string startDate)
        {
            // Create an instance of the viewModel
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

            // Add one day to the end of the date to create a range
            DateTime filterDateEnd = filterDate.AddDays(1);

            // Return the diary entries created by the user and filtered by a date
            var diaryEntries = db.DiaryEntries
                .Include(d => d.Food)
                .Include(d => d.User)
                .Where(d => d.UserId == userId)
                .Where(d => d.DateAdded > filterDate && d.DateAdded < filterDateEnd)
                .OrderByDescending(d => d.DateAdded);

            // Pass the list into the viewModel
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

        public ActionResult DeleteAll(string date)
        {
            if (date == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get user Id
            string userId = User.Identity.GetUserId();

            // Parse the users current date into a datetime object
            DateTime filterDate = DateTime.ParseExact(date, "yyyy-MM-dd", null);

            // Add a day to the date to create a range
            DateTime filterDateEnd = filterDate.AddDays(1);

            // Get the users diary entries between the date range
            var diaryEntries = db.DiaryEntries
                .Where(d => d.UserId == userId)
                .Where(d => d.DateAdded > filterDate && d.DateAdded < filterDateEnd);
            
            // if their are no entries redirect
            if (diaryEntries.Count() == 0)
            {
                // Create an instance of AlertMessage and populate with error message and class name.
                // Pass this object to temp data to be used in the view.
                TempData["UserMessage"] = new AlertMessage() { CssClassName = "alert alert-warning", Title = "Sorry!", Message = "Nothing to delete." };
                return RedirectToAction("Index", new { startDate = date });
            }

            // Remove the entries from the database
            db.DiaryEntries.RemoveRange(diaryEntries);

            // Save changes to the database
            db.SaveChanges();

            TempData["UserMessage"] = new AlertMessage() { CssClassName = "alert alert-success", Title = "Success!", Message = "All entries on " + date + " Deleted." };

            // Pass the date back 
            return RedirectToAction("Index", new { startDate = date });
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
                .Include(d => d.Food)
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
