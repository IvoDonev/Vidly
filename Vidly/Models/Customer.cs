using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MembershipTypeId { get; set; } // treat as a foreign key
        public MembershipType MembershipType { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}