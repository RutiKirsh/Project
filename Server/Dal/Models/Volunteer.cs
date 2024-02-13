using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Volunteer
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public DateTime BirthDate { get; set; }

    public int AddressId { get; set; }

    public string Comments { get; set; }
}
