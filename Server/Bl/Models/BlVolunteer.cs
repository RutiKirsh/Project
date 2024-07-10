using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class BlVolunteer
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public DateTime BirthDate { get; set; }

    public string Comments { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }
    public BlVolunteer(string id, string firstName, string lastName, string phone, DateTime birthDate, string comments, Address address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        BirthDate = birthDate;
        Comments = comments;
        City = address.City;
        Street = address.Street;
        Building = address.Building;
    }
}
