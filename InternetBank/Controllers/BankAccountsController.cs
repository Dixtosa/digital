using Core.Services;
using InternetBank.Models;
using Microsoft.AspNetCore.Mvc;


namespace InternetBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _accountService;

        public BankAccountsController(IBankAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _accountService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var account = await _accountService.GetByIdAsync(id);
            return account == null ? NotFound() : Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBankAccountDto dto)
        {
            var created = await _accountService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateBankAccountDto dto)
        {
            var success = await _accountService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _accountService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}

