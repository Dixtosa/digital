using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService iloanService;

        public LoanController(ILoanService loanService)
        {
            iloanService = loanService;
        }

        [HttpPost("pay-due")]
        public async Task<IActionResult> PayDueLoans()
        {
            var result = await iloanService.ProcessDuePaymentsAsync();

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
