using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class CreateLoanDto
    {
        public int UserId { get; set; }
        public decimal LoanAmount { get; set; }
        public int DurationInMonths { get; set; }
    }
}
