using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelFinder.Entities;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAll();
        Task<Hotel> GetById(int id);
        Task<Hotel> GetByName(string name);
        Task Add(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(Hotel hotel);
    }
}
