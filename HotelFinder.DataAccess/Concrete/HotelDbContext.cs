using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess.Concrete
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
