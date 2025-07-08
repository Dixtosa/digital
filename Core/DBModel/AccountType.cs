using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{
    public class AccountType
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<BankAccount> BankAccounts { get; set; } = new List<BankAccount>();
    }
}
