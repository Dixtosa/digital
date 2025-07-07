using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class TransferDto
    {
        public int SenderAccountId { get; set; }
        public string ReceiverIdentifier { get; set; } = null!; // phone, personalNo, ან accountNumber
        public string IdentifierType { get; set; } = null!; // "phone", "personal" ან "account"
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;
    }
}
