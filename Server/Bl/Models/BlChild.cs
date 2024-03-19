using Dal.Models;
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

    public byte[] Image { get; set; }

    public int AddressId { get; set; }

    public string Comments { get; set; }

    public virtual Address Address { get; set; }

}
