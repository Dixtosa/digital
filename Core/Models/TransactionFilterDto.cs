using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    internal class TransactionFilterDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? UserId { get; set; }
        public int? AccountId { get; set; }
    }
}
