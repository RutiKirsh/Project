﻿using System;
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

        public TypeEnum Type { get; set; }

        public string ChildId { get; set; }

        public string VolunteerId { get; set; }
    }
}
