using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Child
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Challenge { get; set; }

    public DateTime BirthDate { get; set; }

    public byte[] Image { get; set; }

    public int AddressId { get; set; }

    public string Comments { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<VolunteeringTask> VolunteeringTasks { get; set; } = new List<VolunteeringTask>();
}
