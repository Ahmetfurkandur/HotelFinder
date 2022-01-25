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

        /// <summary>
        /// Gets all hotels.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels = await _hotelService.GetAll();
            return Ok(hotels);// 200 + data

        }

        /// <summary>
        /// Gets an hotel by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _hotelService.GetById(id);
            if (hotel!=null)
            {
                return Ok(hotel); //200 + data
            }

            return NotFound();//404 not found error
        }

        /// <summary>
        /// Gets an hotel by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var hotel = await _hotelService.GetByName(name);
            if (hotel!=null)
            {
                return Ok(hotel); //200 + data
            }

            return NotFound();//404 not found error
        }
        /// <summary>
        /// Adds the hotel to database.
        /// </summary>
        /// <param name="hotel"></param>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _hotelService.Add(hotel);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Updates the hotel
        /// </summary>
        /// <param name="hotel"></param>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Hotel hotel)
        {
            if (_hotelService.GetById(hotel.Id)!= null)
            {
                await _hotelService.Update(hotel);
                return Ok();
            }

            return NotFound();
        }
        /// <summary>
        /// Deletes the hotel
        /// </summary>
        /// <param name="hotel"></param>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]Hotel hotel)
        {
            if (_hotelService.GetById(hotel.Id)!= null)
            {
                await _hotelService.Delete(hotel);
                return Ok();
            }

            return NotFound();
        }
    }
}
