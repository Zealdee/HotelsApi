
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Services;
using HotelsApi.Dtos;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangayController : ControllerBase
    {
        private readonly IBarangayService barangayService;

        public BarangayController(IBarangayService barangayService)
        {
            this.barangayService = barangayService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllBarangays()
        {
            var barangays = await barangayService.GetAllBarangays();

            return Ok(barangays);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarangayById([FromRoute] int id)
        {
            var barangay = await barangayService.GetBarangayById(id);
            if (barangay == null)
                return NotFound();

            return Ok(barangay);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateBarangay([FromBody] CreateBarangay barangay)
        {
            var createdBarangayd = await barangayService.CreateBarangay(barangay);

            if (createdBarangayd == null)
                return BadRequest();

            return Ok(createdBarangayd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarangay([FromRoute] int id, [FromBody] UpdateBarangay barangay)
        {
            var updateBarangayResult = await barangayService.UpdateBarangay(id, barangay);

            if (updateBarangayResult == null)
                return BadRequest();

            return Ok(updateBarangayResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarangay([FromRoute] int id)
        {
            var deleteResult = await barangayService.DeleteBarangay(id);
            if (deleteResult == false)
                return BadRequest();

            return Ok(deleteResult);
        }
    }
}
