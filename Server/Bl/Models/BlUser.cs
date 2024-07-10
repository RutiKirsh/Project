using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models
{
    public class BlUser
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }

        public BlChild Child { get; set; }

        public BlVolunteer Volunteer { get; set; }
        public BlUser(string email, string password, string type, BlChild child, BlVolunteer volunteer) {
            Email = email;
            Password = password;
            Type = type;
            Child = child;
            Volunteer = volunteer;
        }
    }
}
