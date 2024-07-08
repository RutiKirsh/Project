using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dal.Models;

public partial class Child
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Challenge { get; set; }

    public DateTime BirthDate { get; set; }

    public string Image { get; set; }

    public int AddressId { get; set; }

    public string Comments { get; set; }

    public virtual Address Address { get; set; }
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    [JsonIgnore]
    public virtual ICollection<VolunteeringTask> VolunteeringTasks { get; set; } = new List<VolunteeringTask>();
}
