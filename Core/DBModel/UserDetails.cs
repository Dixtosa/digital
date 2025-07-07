using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DBModel
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public User User { get; set; } = null!;
    }

}