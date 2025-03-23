
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Services;
using HotelsApi.Dtos;
using HotelsApi.Repositories;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCities()
        {
            var citys = await cityService.GetAllCities();

            return Ok(citys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById([FromRoute] int id)
        {
            var city = await cityService.GetCityById(id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCity([FromBody] CreateCity city)
        {
            var createdCityd = await cityService.CreateCity(city);

            if (createdCityd == null)
                return BadRequest();

            return Ok(createdCityd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity([FromRoute] int id, [FromBody] UpdateCity city)
        {
            var updateCityResult = await cityService.UpdateCity(id, city);

            if (updateCityResult == null)
                return BadRequest();

            return Ok(updateCityResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity([FromRoute] int id)
        {
            var deleteResult = await cityService.DeleteCity(id);
            if (deleteResult == false)
                return BadRequest();

            return Ok(deleteResult);
        }
    }
}
