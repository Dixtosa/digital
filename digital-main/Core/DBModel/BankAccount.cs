using Core.DBModel;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{
    public class BankAccount
    {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string AccountNumber { get; set; } = null!;
    public int AccountTypeId { get; set; }
    public decimal Amount { get; set; }
    public int CurrencyId { get; set; }
    public int UserId { get; set; }
    public int? CardId { get; set; }
    public AccountType AccountType { get; set; } = null!;
    public Currency Currency { get; set; } = null!;
    public User User { get; set; } = null!;
    public Card? Card { get; set; }

    public ICollection<Transactions> SentTransactions { get; set; } = new List<Transactions>();
    public ICollection<Transactions> ReceivedTransactions { get; set; } = new List<Transactions>();
}

}