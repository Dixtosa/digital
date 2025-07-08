using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class TransactionReportDto
    {
       
        public Guid Id { get; set; }
        public Guid? FromAccountId { get; set; }
        public Guid? ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
    }
}

