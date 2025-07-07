using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class CreateBankAccountDto
    {
        public string AccountNumber { get; set; } = null!;
        public int AccountTypeId { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
    }
}
