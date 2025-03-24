
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelsApi.Services;
using HotelsApi.Dtos;

namespace HotelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await transactionService.GetAllTransactions();

            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById([FromRoute] int id)
        {
            var transaction = await transactionService.GetTransactionById(id);
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction transaction)
        {
            var createdTransactiond = await transactionService.CreateTransaction(transaction);

            if (createdTransactiond == null)
                return BadRequest();

            return Ok(createdTransactiond);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromRoute] int id, [FromBody] UpdateTransaction transaction)
        {
            var updateTransactionResult = await transactionService.UpdateTransaction(id, transaction);

            if (updateTransactionResult == null)
                return BadRequest();

            return Ok(updateTransactionResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] int id)
        {
            var deleteResult = await transactionService.DeleteTransaction(id);
            if (deleteResult == false)
                return BadRequest();

            return Ok(deleteResult);
        }
    }
}
