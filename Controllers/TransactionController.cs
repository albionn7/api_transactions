using backend.Data;
using backend.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            var transaction = await _context.Transactions.ToListAsync();
            return Ok(transaction);

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) return NotFound();

            var resultDto = new TransactionDto
            {
                Id = transaction.Id,
                Title = transaction.Title,
                Price = transaction.Price
            };

            return Ok(resultDto);
        }

        [HttpPost]

        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto dto)
        {
            var category = await _context.Categories.FindAsync(dto.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category with ID {dto.CategoryId} does not exist.");
            }

            var transaction = new Transaction
            {
                Title = dto.Title,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(new TransactionDto
            {
                Id = transaction.Id,
                Title = transaction.Title,
                Price = transaction.Price,
                CategoryId = transaction.CategoryId,
                CategoryName = category.Name
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, UpdateTransactionDto dto)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
                return NotFound();

            // Update properties
            transaction.Title = dto.Title;
            transaction.Price = dto.Price;
            transaction.CategoryId = dto.CategoryId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            return NoContent();
        }

       [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
