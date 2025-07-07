using InternetBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services;

namespace InternetBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService iuserService;

        public UsersController(IUserService userService)
        {
            iuserService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await iuserService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await iuserService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var created = await iuserService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUserDto dto)
        {
            var success = await iuserService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await iuserService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet("initials")]
        public async Task<IActionResult> GetUserInitials(string identifier)
        {
            var initials = await iuserService.GetUserInitialsAsync(identifier);

            if (string.IsNullOrEmpty(initials))
                return NotFound("მომხმარებელი ვერ მოიძებნა");

            return Ok(initials);
        }
    }
}


