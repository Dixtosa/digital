using Core.Services;
using InternetBank.Models;
using Microsoft.AspNetCore.Mvc;


namespace InternetBank.Controllers
{
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService iaccountService;

        public BankAccountsController(IBankAccountService accountService)
        {
            iaccountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await iaccountService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var account = await iaccountService.GetByIdAsync(id);
            return account == null ? NotFound() : Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBankAccountDto dto)
        {
            var created = await iaccountService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateBankAccountDto dto)
        {
            var success = await iaccountService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await iaccountService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}

