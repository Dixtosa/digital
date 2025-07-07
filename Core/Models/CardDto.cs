using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class CardDto
    {
       
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameOnCard { get; set; } = null!;
        public string CardNumber { get; set; } = null!;
        public DateTime ValidThru { get; set; }
        public string CVV { get; set; } = null!;
    }
}
