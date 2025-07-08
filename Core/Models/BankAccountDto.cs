using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class BankAccountDto
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; } = null!;
        public int AccountTypeId { get; set; }
        public decimal Amount { get; set; }
        public Guid CurrencyId { get; set; }
        public Guid UserId { get; set; }
    }
}
