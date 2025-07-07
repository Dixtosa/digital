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
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await userService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await userService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var created = await userService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateUserDto dto)
        {
            var success = await userService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await userService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }

        [HttpGet("initials")]
        public async Task<IActionResult> GetUserInitials(string identifier)
        {
            var initials = await userService.GetUserInitialsAsync(identifier);

            if (string.IsNullOrEmpty(initials))
                return NotFound("მომხმარებელი ვერ მოიძებნა");

            return Ok(initials);
        }
    }
}


