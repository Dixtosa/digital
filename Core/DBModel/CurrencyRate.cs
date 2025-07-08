using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{
    public class CurrencyRate
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid CurrencyId { get; set; }
        public decimal Rate { get; set; }

        public Currency Currency { get; set; } = null!;
    }
}
