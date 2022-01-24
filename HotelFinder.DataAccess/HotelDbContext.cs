using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Data Source= (localdb)\mssqllocaldb;Initial catalog= HotelDB;integrated security=true");
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
