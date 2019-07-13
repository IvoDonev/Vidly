using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalController : ApiController
    {

        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
            {
                return BadRequest("No movies for rental supplied");
            }

            // find the customer
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
            {
                return BadRequest("Customer id is not valid");
            }

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
            {
                return BadRequest("One or more movie ids could not be found");
            }

            var dateRented = DateTime.Now;

            foreach (var movieToRent in movies)
            {

                if (movieToRent.NumberAvailable == 0)
                {
                    return BadRequest("Movie not available");
                }

                movieToRent.NumberAvailable--;
                _context.Rentals.Add(new Rental()
                {
                    Movie = movieToRent,
                    Customer = customer,
                    DateRented = dateRented
                });
            }

            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var customerRentals = new CustomerRentalsDto()
            {
                CustomerId = id,
                RentedMovies = _context.Rentals
                    .Where(r => r.DateReturned == null)
                    .Where(r => r.CustomerId == id)
                    .Include(r => r.Movie)
                    .Select(r => new RentedMovieDto()
                    {
                        MovieId = r.Movie.Id,
                        MovieName = r.Movie.Name,
                        DateRented = r.DateRented
                    }).ToList()
            };
            return Ok(customerRentals);
        }

    }
}