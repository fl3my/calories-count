namespace CaloriesCount.Migrations
{
    using CaloriesCount.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CaloriesCount.DAL.CaloriesCountContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CaloriesCount.DAL.CaloriesCountContext context)
        {
            // Create a list of categories
            var categories = new List<Category>
            {
                new Category {Name = "Dairy"},
                new Category {Name = "Vegetables"},
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
                    Fibre = 2.2,
                    ImageFileName = "basmati_rice.jpg",
                    CategoryId = categories.Single(c => c.Name == "Grains").Id
                },
                new Food
                {
                    Name = "Apple",
                    Calories = 57,
                    Fat = 0,
                    Protein = 0,
                    Carbohydrates =14 ,
                    Fibre = 1.5,
                    ImageFileName = "apple_on_white.jpg",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Banana",
                    Calories = 181,
                    Fat = 0.55,
                    Protein = 1.8,
                    Carbohydrates = 42,
                    Fibre = 2,
                    ImageFileName = "banana_bunch.jpg",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Sweet Potato",
                    Calories = 99,
                    Fat = 0,
                    Protein = 1.7,
                    Carbohydrates = 20,
                    Fibre = 2.6,
                    ImageFileName = "new_potatoes.jpg",
                    CategoryId = categories.Single(c => c.Name == "Vegetables").Id
                },
                new Food
                {
                    Name = "Broccoli",
                    Calories = 35,
                    Fat = 0,
                    Protein = 2.4,
                    Carbohydrates = 4.7,
                    Fibre = 2.4,
                    ImageFileName = "broccoli.jpg",
                    CategoryId = categories.Single(c => c.Name == "Vegetables").Id
                },
                new Food
                {
                    Name = "Chicken",
                    Calories = 114,
                    Fat = 3.2,
                    Protein = 21,
                    Carbohydrates = 0.4,
                    Fibre = 0,
                    ImageFileName = "carving_roast_chicken.jpg",
                    CategoryId = categories.Single(c => c.Name == "Meat").Id
                },
                new Food
                {
                    Name = "Salmon",
                    Calories = 120,
                    Fat = 6,
                    Protein = 20,
                    Carbohydrates = 0,
                    Fibre = 0,
                    ImageFileName = "cooking_salmon.jpg",
                    CategoryId = categories.Single(c => c.Name == "Seafood").Id
                },
                new Food
                {
                    Name = "Cheddar Cheese",
                    Calories = 417,
                    Fat = 33,
                    Protein = 27,
                    Carbohydrates = 4.2,
                    Fibre = 0,
                    ImageFileName = "cheese_grated.jpg",
                    CategoryId = categories.Single(c => c.Name == "Dairy").Id
                },
                new Food
                {
                    Name = "Cottage Cheese",
                    Calories = 97,
                    Fat = 4.4,
                    Protein = 12,
                    Carbohydrates = 4.4,
                    Fibre = 0,
                    ImageFileName = "cottage_cheese.jpg",
                    CategoryId = categories.Single(c => c.Name == "Dairy").Id
                },
                new Food
                {
                    Name = "Dark Chocolate",
                    Calories = 500,
                    Fat = 33,
                    Protein = 5,
                    Carbohydrates = 48,
                    Fibre = 7.5,
                    ImageFileName = "block_chocolate.jpg",
                    CategoryId = categories.Single(c => c.Name == "Snacks").Id
                },
                new Food
                {
                    Name = "Bread Roll",
                    Calories = 298,
                    Fat = 4.4,
                    Protein = 9.1,
                    Carbohydrates = 49,
                    Fibre = 1.8,
                    ImageFileName = "bread_roll.jpg",
                    CategoryId = categories.Single(c => c.Name == "Grains").Id
                },
                new Food
                {
                    Name = "Cooked Tagliatelle",
                    Calories = 378,
                    Fat = 4,
                    Protein = 14,
                    Carbohydrates = 70,
                    Fibre = 1.6,
                    ImageFileName = "cooked_tagliatelle.jpg",
                    CategoryId = categories.Single(c => c.Name == "Grains").Id
                },
                new Food
                {
                    Name = "Cracker",
                    Calories = 321,
                    Fat = 11,
                    Protein = 5.3,
                    Carbohydrates = 50,
                    Fibre = 2.6,
                    ImageFileName = "cracker.jpg",
                    CategoryId = categories.Single(c => c.Name == "Grains").Id
                },
                new Food
                {
                    Name = "White Bread",
                    Calories = 282,
                    Fat = 3.3,
                    Protein = 8.7,
                    Carbohydrates = 50,
                    Fibre = 2.2,
                    ImageFileName = "batard.jpg",
                    CategoryId = categories.Single(c => c.Name == "Grains").Id
                },
                new Food
                {
                    Name = "Egg",
                    Calories = 140,
                    Fat = 10,
                    Protein = 12,
                    Carbohydrates = 0,
                    Fibre = 0,
                    ImageFileName = "farm_fresh_eggs.jpg",
                    CategoryId = categories.Single(c => c.Name == "Dairy").Id
                },
                new Food
                {
                    Name = "Beer",
                    Calories = 43,
                    Fat = 0,
                    Protein = 0.46,
                    Carbohydrates = 3,
                    Fibre = 0,
                    ImageFileName = "beer_glass.jpg",
                    CategoryId = categories.Single(c => c.Name == "Drinks").Id
                },
                new Food
                {
                    Name = "Wine",
                    Calories = 155,
                    Fat = 0,
                    Protein = 0,
                    Carbohydrates = 3.2,
                    Fibre = 0,
                    ImageFileName = "champagne_bottle_glasses.jpg",
                    CategoryId = categories.Single(c => c.Name == "Drinks").Id
                },
                new Food
                {
                    Name = "Latte",
                    Calories = 325,
                    Fat = 8.7,
                    Protein = 10,
                    Carbohydrates = 55,
                    Fibre = 0,
                    ImageFileName = "coffee_to_go.jpg",
                    CategoryId = categories.Single(c => c.Name == "Drinks").Id
                },
                new Food
                {
                    Name = "Avocado",
                    Calories = 159,
                    Fat = 15,
                    Protein = 1.9,
                    Carbohydrates = 8.6,
                    Fibre = 6.8,
                    ImageFileName = "avocado_flesh.jpg",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Grape",
                    Calories = 200,
                    Fat = 0,
                    Protein = 2.5,
                    Carbohydrates = 55,
                    Fibre = 2.5,
                    ImageFileName = "black_grapes.jpg",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Raspberries",
                    Calories = 57,
                    Fat = 0.3,
                    Protein = 1,
                    Carbohydrates = 13,
                    Fibre = 2.9,
                    ImageFileName = "harvested_raspberries.jpg",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Strawberries",
                    Calories = 36,
                    Fat = 0,
                    Protein = 0.71,
                    Carbohydrates = 9.3,
                    Fibre = 2.1,
                    ImageFileName = "ripened_red_strawberries.jpg",
                    CategoryId = categories.Single(c => c.Name == "Fruits").Id
                },
                new Food
                {
                    Name = "Bacon",
                    Calories = 533,
                    Fat = 40,
                    Protein = 33,
                    Carbohydrates = 0,
                    Fibre = 0,
                    ImageFileName = "bacon_and_mushrooms.jpg",
                    CategoryId = categories.Single(c => c.Name == "Meat").Id
                },
                new Food
                {
                    Name = "Beef Mince",
                    Calories = 183,
                    Fat = 11,
                    Protein = 20,
                    Carbohydrates = 0,
                    Fibre = 0,
                    ImageFileName = "beef_mince.jpg",
                    CategoryId = categories.Single(c => c.Name == "Meat").Id
                },
                new Food
                {
                    Name = "Sausage",
                    Calories = 322,
                    Fat = 27,
                    Protein = 18,
                    Carbohydrates = 1.8,
                    Fibre = 0,
                    ImageFileName = "sausage.jpg",
                    CategoryId = categories.Single(c => c.Name == "Meat").Id
                },
                new Food
                {
                    Name = "Swordfish",
                    Calories = 142,
                    Fat = 6.2,
                    Protein = 19,
                    Carbohydrates = 0,
                    Fibre = 0,
                    ImageFileName = "fresh_swordfish.jpg",
                    CategoryId = categories.Single(c => c.Name == "Seafood").Id
                },
                new Food
                {
                    Name = "Pizza",
                    Calories = 237,
                    Fat = 9.4,
                    Protein = 9.4,
                    Carbohydrates = 26,
                    Fibre = 1.4,
                    ImageFileName = "whole_pizza.jpg",
                    CategoryId = categories.Single(c => c.Name == "Snacks").Id
                },
                new Food
                {
                    Name = "Crisps",
                    Calories = 536,
                    Fat = 32,
                    Protein = 7.1,
                    Carbohydrates = 57,
                    Fibre = 3.6,
                    ImageFileName = "potato_chips_on_white.jpg",
                    CategoryId = categories.Single(c => c.Name == "Snacks").Id
                },
                new Food
                {
                    Name = "basic sponge cream cake",
                    Calories = 387,
                    Fat = 16,
                    Protein = 3.8,
                    Carbohydrates = 51,
                    Fibre = 1.6,
                    ImageFileName = "basic_sponge_cream_cake.jpg",
                    CategoryId = categories.Single(c => c.Name == "Snacks").Id
                },
                new Food
                {
                    Name = "Sweet corn",
                    Calories = 100,
                    Fat = 1.1,
                    Protein = 2.2,
                    Carbohydrates = 20,
                    Fibre = 2.2,
                    ImageFileName = "buttery_sweet_corn.jpg",
                    CategoryId = categories.Single(c => c.Name == "Vegetables").Id
                },
                new Food
                {
                    Name = "Carrot",
                    Calories = 25,
                    Fat = 0,
                    Protein = 0.83,
                    Carbohydrates = 5,
                    Fibre = 1.7,
                    ImageFileName = "carrot_slices.jpg",
                    CategoryId = categories.Single(c => c.Name == "Vegetables").Id
                },
                new Food
                {
                    Name = "Cucumber",
                    Calories = 13,
                    Fat = 0,
                    Protein = 0.7,
                    Carbohydrates = 2.8,
                    Fibre = 0.7,
                    ImageFileName = "cucumber.jpg",
                    CategoryId = categories.Single(c => c.Name == "Vegetables").Id
                }
            };

            foods.ForEach(c => context.Foods.AddOrUpdate(f => f.Name, c));
            context.SaveChanges();

                // Create a few roles and store them in roles table

                // Create a role Manager object that will allow us to create roles
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                // If the Admin role doesnt exist
                if (!roleManager.RoleExists("Admin"))
                {
                    // Create an admin role
                    roleManager.Create(new IdentityRole("Admin"));
                }

                // If the member role doesnt exist
                if (!roleManager.RoleExists("Member"))
                {
                    // create a Member role
                    roleManager.Create(new IdentityRole("Member"));
                }

                context.SaveChanges();

                // Create some users and assign to different roles

                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Create a user admin
                if (userManager.FindByName("admin@admin.com") == null)
                {
                    var admin = new ApplicationUser()
                    {
                        UserName = "admin@admin.com",
                        Email = "admin@admin.com",
                        FirstName = "Ross",
                        LastName = "Fleming",
                        EmailConfirmed = true,
                        DailyCalories = 2000

                    };

                    // add a hashed password to the user
                    userManager.Create(admin, "Admin123!");

                    // add the user to the role Admin
                    userManager.AddToRole(admin.Id, "Admin");
                }

                // Create a member
                var member = new ApplicationUser()
                {
                    UserName = "member@member.com",
                    Email = "member@member.com",
                    FirstName = "Member",
                    LastName = "Memberton",
                    EmailConfirmed = true,
                    DailyCalories = 2500
                };

                if (userManager.FindByName("member@member.com") == null)
                {
                    userManager.Create(member, "Password123!");
                    userManager.AddToRole(member.Id, "Member");
                }

                context.SaveChanges();
            
        }
    }
}
