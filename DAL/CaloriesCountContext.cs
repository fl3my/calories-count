using CaloriesCount.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaloriesCount.DAL
{
    public class CaloriesCountContext:DbContext
    {
        // Tell Entity framework to use the model class to represent a row in the models table
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}