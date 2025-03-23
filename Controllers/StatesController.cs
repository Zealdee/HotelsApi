
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Services;
using HotelsApi.Dtos;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService stateService;

        public StateController(IStateService stateService)
        {
            this.stateService = stateService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllStates()
        {
            var states = await stateService.GetAllStates();

            return Ok(states);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateById([FromRoute] int id)
        {
            var state = await stateService.GetStateById(id);
            if (state == null)
                return NotFound();

            return Ok(state);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateState([FromBody] CreateState state)
        {
            var createdStated = await stateService.CreateState(state);

            if (createdStated == null)
                return BadRequest();

            return Ok(createdStated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateState([FromRoute] int id, [FromBody] UpdateState state)
        {
            var updateStateResult = await stateService.UpdateState(id, state);

            if (updateStateResult == null)
                return BadRequest();

            return Ok(updateStateResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState([FromRoute] int id)
        {
            var deleteResult = await stateService.DeleteState(id);
            if (deleteResult == false)
                return BadRequest();

            return Ok(deleteResult);
        }
    }
}
