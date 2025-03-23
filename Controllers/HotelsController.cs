﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Services;
using HotelsApi.Dtos;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await hotelService.GetAllHotels();

            return Ok(hotels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById([FromRoute] int id)
        {
            var hotel = await hotelService.GetHotelById(id);
            if (hotel == null)
                return NotFound();

            return Ok(hotel);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotel hotel)
        {
            var createdHoteld = await hotelService.CreateHotel(hotel);

            if (createdHoteld == null)
                return BadRequest();

            return Ok(createdHoteld);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel([FromRoute] int id, [FromBody] UpdateHotel hotel)
        {
            var updateHotelResult = await hotelService.UpdateHotel(id, hotel);

            if (updateHotelResult == null)
                return BadRequest();

            return Ok(updateHotelResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel([FromRoute] int id)
        {
            var deleteResult = await hotelService.DeleteHotel(id);
            if (deleteResult == false)
                return BadRequest();

            return Ok(deleteResult);
        }
    }
}
