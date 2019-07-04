using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleNames.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ListReadOnly");

            }
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include("Genre").FirstOrDefault(c => c.Id == id);
            if (movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult New()
        {
            return View(new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            });
        }


        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include("Genre").FirstOrDefault(c => c.Id == id);
            if (movie != null)
            {
                return View("New", new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                });
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                // new customer
                var newMovie = new Movie()
                {
                    Name = viewModel.Name,
                    GenreId = viewModel.GenreId.Value,
                    NumberInStock = viewModel.NumberInStock.Value,
                    ReleaseDate = viewModel.ReleaseDate.Value,
                    DateAdded = DateTime.Now
                };
                _context.Movies.Add(newMovie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == viewModel.Id);
                movieInDb.GenreId = viewModel.GenreId.Value;
                movieInDb.NumberInStock = viewModel.NumberInStock.Value;
                movieInDb.ReleaseDate = viewModel.ReleaseDate.Value;
                movieInDb.Name = viewModel.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}