using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Models
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public Int16 Level { get; set; }
    }
}
