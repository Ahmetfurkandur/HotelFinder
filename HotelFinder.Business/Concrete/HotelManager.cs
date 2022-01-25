using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<Hotel>> GetAll()
        {
            return await _hotelRepository.GetAll();
        }

        public async Task<Hotel> GetById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository.GetById(id);
            }

            throw new Exception("Id can not be less than 1 ");
        }

        public async Task<Hotel> GetByName(string name)
        {
            return await _hotelRepository.GetByName(name);
        }

        public async Task Add(Hotel hotel)
        {
            await _hotelRepository.Add(hotel);
        }

        public async Task Update(Hotel hotel)
        {
            await _hotelRepository.Update(hotel);
        }

        public async Task Delete(Hotel hotel)
        {
            await _hotelRepository.Delete(hotel);
        }
    }
}
