
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Services;
using HotelsApi.Dtos;


namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCountries()
        {
            var countrys = await countryService.GetAllCountries();

            return Ok(countrys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById([FromRoute] int id)
        {
            var country = await countryService.GetCountryById(id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountry country)
        {
            var createdCountryd = await countryService.CreateCountry(country);

            if (createdCountryd == null)
                return BadRequest();

            return Ok(createdCountryd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry([FromRoute] int id, [FromBody] UpdateCountry country)
        {
            var updateCountryResult = await countryService.UpdateCountry(id, country);

            if (updateCountryResult == null)
                return BadRequest();

            return Ok(updateCountryResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            var deleteResult = await countryService.DeleteCountry(id);
            if (deleteResult == false)
                return BadRequest();

            return Ok(deleteResult);
        }
    }
}
