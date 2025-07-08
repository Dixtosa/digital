using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{
    public class Transactions
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid SenderAccountId { get; set; }
        public Guid ReceiverAccountId { get; set; }
        public string ReceiverAccount { get; set; } = null!;
        public decimal Amount { get; set; }
        public Guid CurrencyId { get; set; }
        public string Description { get; set; } = null!;

        public BankAccount SenderAccount { get; set; } = null!;
        public BankAccount ReceiverAccountNav { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
    }
}