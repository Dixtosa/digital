using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class UserInfoDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials => $"{FirstName?.FirstOrDefault()}. {LastName?.FirstOrDefault()}.";
    }
}
