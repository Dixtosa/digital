﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBank.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
