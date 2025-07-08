using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.DBModel
{

    public class Card
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public int BankAccountId { get; set; }
        public string NameOnCard { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public DateTime ValidThru { get; set; }
        public string CVV { get; set; } = null!;

        public User User { get; set; } = null!;
        public BankAccount BankAccount { get; set; } = null!;
    }

}