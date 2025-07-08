using Core.Services;
using InternetBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanLimitController : ControllerBase
    {
        private readonly ILoanLimitService iloanLimitService;

        public LoanLimitController(ILoanLimitService loanLimitService)
        {
            iloanLimitService = loanLimitService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLimit([FromBody] CreateLoanLimitDto dto)
        {
            var result = await iloanLimitService.CreateLimitAsync(dto);
            if (!result)
                return BadRequest("მომხმარებელი ვერ მოიძებნა");

            return Ok("სესხის ლიმიტი წარმატებით დაემატა");
        }

    }
}
