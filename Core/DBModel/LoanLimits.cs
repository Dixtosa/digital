using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{
    public class LoanLimits
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }

        public User User { get; set; } = null!;
    }
}
