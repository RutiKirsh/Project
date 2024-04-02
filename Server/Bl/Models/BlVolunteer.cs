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

    public virtual Address Address { get; set; }
    public BlVolunteer(string id, string firstName, string lastName, string phone, DateTime birthDate, string comments, Address address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        BirthDate = birthDate;
        Comments = comments;
        Address = address;    
    }
}
