using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{

    public class Loans
    {
        public int Id { get; set; }
        public decimal LoanAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid UserId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public DateTime LoanDate { get; set; }
        public decimal LoanRemainigAmount { get; set; }
        public decimal MonthlyPaymentAmount { get; set; }
        public Guid BankAccountId { get; set; }
    }

}