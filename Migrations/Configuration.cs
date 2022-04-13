namespace CaloriesCount.Migrations
{
    using CaloriesCount.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CaloriesCount.DAL.CaloriesCountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CaloriesCount.DAL.CaloriesCountContext";
        }

        protected override void Seed(CaloriesCount.DAL.CaloriesCountContext context)
        {
            // Create a list of categories
            var categories = new List<Category>
            {
                new Category {Name = "Dairy"},
                new Category {Name = "Vegetables"},
                new Category {Name = "Bread"},
                new Category {Name = "Fruits"},
                new Category {Name = "Seafood"},
                new Category {Name = "Meat"},
                new Category {Name = "Drinks"},
                new Category {Name = "Snacks"}
            };

            // Add or update a category if there is not one with the same name already
            // in the database
            categories.ForEach(c => context.Categories.AddOrUpdate(f => f.Name, c));

            // save changes to the database
            context.SaveChanges();

            var foods = new List<Food>
            {
                new Food
                {
                    Name = "Apple",
                    Calories = 100,
                    Fat = 1,
                    Protein = 1,
                    Carbohydrates = 1,
                    fibre = 1,
                    ImageURL = "pic",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Grape",
                    Calories = 50,
                    Fat = 1,
                    Protein = 1,
                    Carbohydrates = 1,
                    fibre = 1,
                    ImageURL = "pic",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Carrot",
                    Calories = 100,
                    Fat = 1,
                    Protein = 1,
                    Carbohydrates = 1,
                    fibre = 1,
                    ImageURL = "pic",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                }
            };

            foods.ForEach(c => context.Foods.AddOrUpdate(f => f.Name, c));
            context.SaveChanges();
        }
    }
}
