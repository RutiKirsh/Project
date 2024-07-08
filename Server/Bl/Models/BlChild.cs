using Dal.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class BlChild
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Challenge { get; set; }

    public DateTime BirthDate { get; set; }

    public string ImageURL { get; set; }

    public string Comments { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }

    public virtual Address Address { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }
    public BlChild(string id, string firstName, string lastName, string phone, string challenge, DateTime dateTime, string image, string comments, Address address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Challenge = challenge;
        BirthDate = dateTime;
        ImageURL = image;
        Comments = comments;
        City = address.City;
        Street = address.Street;
        Building = address.Building;
    }

}
