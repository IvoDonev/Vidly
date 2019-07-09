using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(
                    _context.Movies
                    .Include("Genre").
                    Select(Mapper.Map<Movie, MovieDto>)
                    .ToList());
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.NumberAvailable = movie.NumberInStock;  // initially everything is available

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), Mapper.Map<Movie, MovieDto>(movie));
        }

        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieInDb);
            movieInDb.NumberAvailable = movieInDb.NumberInStock;
            _context.SaveChanges();
        }

        // DELETE /api/movies/5
        [HttpDelete]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }


    }
}