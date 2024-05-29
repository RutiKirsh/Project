using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dal.Models;

public partial class Address
{
    public int Id { get; set; }

    public string City { get; set; }

    public string Street { get; set; }

    public string Building { get; set; }
    [JsonIgnore]
    public virtual ICollection<Child> Children { get; set; } = new List<Child>();
    [JsonIgnore]
    public virtual ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
}
