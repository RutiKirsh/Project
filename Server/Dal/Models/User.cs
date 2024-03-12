﻿using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public int Type { get; set; }

    public string ChildId { get; set; }

    public string VolunteerId { get; set; }

    public virtual Child Child { get; set; }

    public virtual Volunteer Volunteer { get; set; }
}
