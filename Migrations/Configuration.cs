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
                new Category {Name = "Snacks"},
                new Category {Name = "Grains"}
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
                    Name = "White Rice Raw",
                    Calories = 356,
                    Fat = 0,
                    Protein = 6.7,
                    Carbohydrates = 80,
                    fibre = 2.2,
                    CategoryId = categories.Single(c => c.Name == "Grains").Id
                },
                new Food
                {
                    Name = "Brown rice Raw",
                    Calories = 354,
                    Fat = 3.1,
                    Protein = 8.3,
                    Carbohydrates = 73,
                    fibre = 4.2,
                    CategoryId = categories.Single(c => c.Name == "Grains").Id
                },
                new Food
                {
                    Name = "Apple",
                    Calories = 57,
                    Fat = 0,
                    Protein = 0,
                    Carbohydrates =14 ,
                    fibre = 1.5,
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Banana",
                    Calories = 181,
                    Fat = 0.55,
                    Protein = 1.8,
                    Carbohydrates = 42,
                    fibre = 2,
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Banana",
                    Calories = 181,
                    Fat = 0.55,
                    Protein = 1.8,
                    Carbohydrates = 42,
                    fibre = 2,
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Sweet Potato",
                    Calories = 99,
                    Fat = 0,
                    Protein = 1.7,
                    Carbohydrates = 20,
                    fibre = 2.6,
                    CategoryId = categories.Single(c => c.Name == "Vegetables").Id
                },
                new Food
                {
                    Name = "Broccoli",
                    Calories = 35,
                    Fat = 0,
                    Protein = 2.4,
                    Carbohydrates = 4.7,
                    fibre = 2.4,
                    CategoryId = categories.Single(c => c.Name == "Vegetables").Id
                },
                new Food
                {
                    Name = "Chicken",
                    Calories = 114,
                    Fat = 3.2,
                    Protein = 21,
                    Carbohydrates = 0.4,
                    fibre = 0,
                    CategoryId = categories.Single(c => c.Name == "Meat").Id
                },
                new Food
                {
                    Name = "Salmon",
                    Calories = 120,
                    Fat = 6,
                    Protein = 20,
                    Carbohydrates = 0,
                    fibre = 0,
                    CategoryId = categories.Single(c => c.Name == "Seafood").Id
                },
                new Food
                {
                    Name = "Cheddar Cheese",
                    Calories = 417,
                    Fat = 33,
                    Protein = 27,
                    Carbohydrates = 4.2,
                    fibre = 0,
                    CategoryId = categories.Single(c => c.Name == "Dairy").Id
                },
                new Food
                {
                    Name = "Cottage Cheese",
                    Calories = 97,
                    Fat = 4.4,
                    Protein = 12,
                    Carbohydrates = 4.4,
                    fibre = 0,
                    CategoryId = categories.Single(c => c.Name == "Dairy").Id
                },
                new Food
                {
                    Name = "Milk Chocolate",
                    Calories = 525,
                    Fat = 30,
                    Protein = 5,
                    Carbohydrates = 60,
                    fibre = 2.5,
                    CategoryId = categories.Single(c => c.Name == "Snacks").Id
                },
                new Food
                {
                    Name = "Dark Chocolate",
                    Calories = 500,
                    Fat = 33,
                    Protein = 5,
                    Carbohydrates = 48,
                    fibre = 7.5,
                    CategoryId = categories.Single(c => c.Name == "Snacks").Id
                }
            };

            foods.ForEach(c => context.Foods.AddOrUpdate(f => f.Name, c));
            context.SaveChanges();
        }
    }
}
