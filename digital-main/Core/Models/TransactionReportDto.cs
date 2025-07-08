using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class TransactionReportDto
    {
        public List<TransactionDto> Transactions { get; set; } = [];
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal NetAmount { get; set; }
    }
}
