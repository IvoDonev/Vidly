using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class RentedMovieDto
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime? DateRented { get; set; }
    }
}