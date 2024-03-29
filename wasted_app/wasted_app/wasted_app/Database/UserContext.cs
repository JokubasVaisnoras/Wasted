﻿using Microsoft.EntityFrameworkCore;
using wasted_app.Tables;
using Xamarin.Essentials;
using System.IO;
using System;

namespace wasted_app.Database
{
    public class UserContext : DbContext
    {
        public virtual DbSet<RegUserTable> Users { get; set; }

        public UserContext()
        {
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Users0.db");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
