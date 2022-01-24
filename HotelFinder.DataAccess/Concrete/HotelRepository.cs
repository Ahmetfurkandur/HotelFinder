using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository:IHotelRepository
    {
        public List<Hotel> GetAll()
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                return context.Set<Hotel>().ToList();
            }
        }

        public Hotel GetById(int id)
        {
            using (HotelDbContext context= new HotelDbContext())
            {
                return context.Set<Hotel>().SingleOrDefault(x => x.Id == id);
            }
        }

        public void Add(Hotel hotel)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                var addedEntity = context.Entry(hotel);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Hotel hotel)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                var updatedEntity = context.Entry(hotel);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Hotel hotel)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                var deletedEntity = context.Entry(hotel);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
