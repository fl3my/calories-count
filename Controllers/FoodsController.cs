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
using PagedList;

namespace CaloriesCount.Controllers
{
    public class FoodsController : Controller
    {
        private CaloriesCountContext db = new CaloriesCountContext();

        // GET: Foods
        public ActionResult Index(string category, string search, string sortBy, int? page)
        {
            // Initialise the view model
            FoodIndexViewModel viewModel = new FoodIndexViewModel();

            // Tell Entity framework to retrive all foods and related categories
            var foods = db.Foods.Include(f => f.Category);

            // if the search property has a value, find the foods that contain the search text
            if (!String.IsNullOrEmpty(search))
            {
                foods = foods.Where(f => f.Name.Contains(search) || f.Category.Name.Contains(search));

                // Store the search in the viewModel so it can be reused
                viewModel.Search = search;
            }

            // Linq Statement, query syntax
            // Group foods together by category name where the category id is not null
            viewModel.CategoriesWithCounts = from matchingFoods in foods
                                           where
                                           matchingFoods.CategoryId != null
                                           group matchingFoods by
                                           matchingFoods.Category.Name into
                                           categoryGroup
                                           select new CategoryWithCount()
                                           {
                                               CategoryName = categoryGroup.Key,
                                               FoodCount = categoryGroup.Count()
                                           };

            // If the category parameter has a value, filter the list to the category
            if (!String.IsNullOrEmpty(category))
            {
                foods = foods.Where(f => f.Category.Name == category);
                viewModel.Category = category;
            }

            // Sort results
            switch (sortBy)
            {
                case "calories_low":
                    foods = foods.OrderBy(f => f.Calories);
                    break;
                case "calories_high":
                    foods = foods.OrderByDescending(f => f.Calories);
                    break;
                case "fat_low":
                    foods = foods.OrderBy(f => f.Fat);
                    break;
                case "fat_high":
                    foods = foods.OrderByDescending(f => f.Fat);
                    break;
                default:
                    foods = foods.OrderBy(f => f.Name);
                    break;
            }

            // set the number of items per page to 3
            const int PageItems = 6;

            // hold the current page number
            int currentPage = (page ?? 1);
            viewModel.Foods = foods.ToPagedList(currentPage, PageItems);

            // preserve the sort order
            viewModel.SortBy = sortBy;

            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Calories low to high", "calories_low" },
                {"Calories high to low", "calories_high" },
                {"Fat low to high", "fat_low" },
                {"Fat high to low", "fat_high" },
            };

            return View(viewModel);
        }

        // GET: Foods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Foods/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Calories,Fat,Protein,Carbohydrates,Fibre,CategoryId")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", food.CategoryId);
            return View(food);
        }

        // GET: Foods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", food.CategoryId);
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Calories,Fat,Protein,Carbohydrates,Fibre,CategoryId")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", food.CategoryId);
            return View(food);
        }

        // GET: Foods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
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
