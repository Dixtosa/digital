using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class TransactionReportRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? AccountId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
    public class TransactionReportResponseDto
    {
        public List<TransactionDto> Transactions { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal TotalOutcome { get; set; }
    }
}

