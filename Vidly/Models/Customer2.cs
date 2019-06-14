using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer2
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MembershipTypeId { get; set; } // treat as a foreign key
        public MembershipType MembershipType { get; set; }
    }
}