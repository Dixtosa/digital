using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{

    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
        public ICollection<Transactions> Transactions { get; set; } = new List<Transactions>();
        public ICollection<CurrencyRate> Rates { get; set; } = new List<CurrencyRate>();
    }
}
