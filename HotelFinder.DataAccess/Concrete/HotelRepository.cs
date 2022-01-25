using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository:IHotelRepository
    {
        public async Task<List<Hotel>> GetAll()
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                return await context.Set<Hotel>().ToListAsync();
            }
        }

        public async Task<Hotel> GetById(int id)
        {
            using (HotelDbContext context= new HotelDbContext())
            {
                return await context.Set<Hotel>().SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<Hotel> GetByName(string name)
        {
            using (HotelDbContext context= new HotelDbContext())
            {
                return await context.Set<Hotel>().SingleOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
        }

        public async Task Add(Hotel hotel)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                var addedEntity = context.Entry(hotel);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Hotel hotel)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                var updatedEntity = context.Entry(hotel);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Hotel hotel)
        {
            using (HotelDbContext context = new HotelDbContext())
            {
                var deletedEntity = context.Entry(hotel);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }
}
