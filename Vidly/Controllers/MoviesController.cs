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
            return View(new MoviesViewModel()
            {
                Movies = _context.Movies.Include("Genre").ToList()
            });
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Movies.Include("Genre").FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}