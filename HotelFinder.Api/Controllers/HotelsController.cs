using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Concrete;

namespace HotelFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        //IHotelService hotelService
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public List<Hotel> Get()
        {
            return _hotelService.GetAll();

        }

        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _hotelService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody]Hotel hotel)
        {
            _hotelService.Add(hotel);
        }

        [HttpPut]
        public void Put([FromBody]Hotel hotel)
        {
            _hotelService.Update(hotel);
        }

        [HttpDelete]
        public void Delete([FromBody]Hotel hotel)
        {
            _hotelService.Delete(hotel);
        }
    }
}
