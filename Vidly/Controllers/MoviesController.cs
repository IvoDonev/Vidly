using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesViewModel viewModel = new MoviesViewModel()
        {
            Movies = new List<Models.Movie>()
            {
                new Models.Movie() { Name = "Shrek", Id = 1 },
                new Models.Movie() { Name = "Cinderella", Id = 2}
            }
        };

        // GET: Movies
        public ActionResult Index()
        {
            return View(viewModel);
        }
    }
}