using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.Entities;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {
        
        List<Hotel> GetAll();
        Hotel GetById(int id);
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(Hotel hotel);
    }
}
