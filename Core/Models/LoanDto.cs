using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class LoanDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal LoanRemainingAmount { get; set; }
        public decimal MonthlyPaymentAmount { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }
        public DateTime LoanDate { get; set; }
        public int BankAccountId { get; set; }
    }

}
