using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int MembershipTypeId { get; set; } // treat as a foreign key
        public DateTime? BirthDate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
    }
}