using Core.Services;
using InternetBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService cardService;

        public CardsController(ICardService cardService)
        {
            cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCardDto dto)
        {
            var created = await cardService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await cardService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await cardService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await cardService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}

