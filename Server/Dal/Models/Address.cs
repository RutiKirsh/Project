using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Address
{
    public int Id { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Building { get; set; }

    public virtual ICollection<Child> Children { get; set; } = new List<Child>();

    public virtual ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
}
