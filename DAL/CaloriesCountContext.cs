using CaloriesCount.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaloriesCount.DAL
{
    public class CaloriesCountContext:IdentityDbContext<ApplicationUser>
    {
        // Tell Entity framework to use the model class to represent a row in the models table
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }
        public DbSet<Message> Messages { get; set; }
        public CaloriesCountContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CaloriesCountContext Create()
        {
            return new CaloriesCountContext();
        }
    }
}