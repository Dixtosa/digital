using Core.Services;
using InternetBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InternetBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("report")]
        public async Task<IActionResult> GetReport([FromBody] TransactionReportRequestDto request)
        {
            var result = await _transactionService.GetTransactionReportAsync(request);
            return Ok(result);
        }
    }
}

