using Dal.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Models;

public class PostChild
{
    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Challenge { get; set; }

    public DateTime BirthDate { get; set; }

    public IFormFile Image { get; set; }

    public string Comments { get; set; }

    public string City { get; set; }
    public string Street { get; set; }
    public string Building { get; set; }


}
