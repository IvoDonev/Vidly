using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class ReturnsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReturnsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(int id = -1)
        {
            var rental = _context.Rentals.Single(r => r.Id == id);
            rental.DateReturned = DateTime.Now;

            var rentedMovie = _context.Movies.Single(m => m.Id == rental.MovieId);
            rentedMovie.NumberAvailable += 1;

            _context.SaveChanges();
            return Ok();
        }

    }
}
