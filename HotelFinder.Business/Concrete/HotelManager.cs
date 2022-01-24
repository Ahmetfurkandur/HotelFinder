using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager:IHotelService
    {
        private IHotelRepository _hotelRepository;
        
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public List<Hotel> GetAll()
        {
            return _hotelRepository.GetAll();
        }

        public Hotel GetById(int id)
        {
            if (id > 0)
            {
                return _hotelRepository.GetById(id);
            }

            throw new Exception("Id can not be less than 1 ");
        }

        public void Add(Hotel hotel)
        {
            _hotelRepository.Add(hotel);
        }

        public void Update(Hotel hotel)
        {
            _hotelRepository.Update(hotel);
        }

        public void Delete(Hotel hotel)
        {
            _hotelRepository.Delete(hotel);
        }
    }
}
