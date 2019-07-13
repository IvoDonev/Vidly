using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class CustomerRentalsDto
    {
        public int CustomerId { get; set; }
        public List<RentedMovieDto>  RentedMovies { get; set;}
    }
}