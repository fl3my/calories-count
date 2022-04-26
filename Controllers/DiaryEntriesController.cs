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
using Microsoft.AspNet.Identity;

namespace CaloriesCount.Controllers
{
    [Authorize]
    public class DiaryEntriesController : Controller
    {
        private CaloriesCountContext db = new CaloriesCountContext();

        // GET: DiaryEntries
        public ActionResult Index()
        {
            var diaryEntries = db.DiaryEntries.Include(d => d.Food).Include(d => d.User);
            return View(diaryEntries.ToList());
        }

        // GET: DiaryEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);
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
        public ActionResult Create([Bind(Include = "Id,Quantity,TotalCalories,FoodId")] DiaryEntry diaryEntry)
        {
            diaryEntry.DateAdded = DateTime.Now;
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
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,DateAdded,Quantity,TotalCalories,FoodId")] DiaryEntry diaryEntry)
        {
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
            DiaryEntry diaryEntry = db.DiaryEntries.Find(id);
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
