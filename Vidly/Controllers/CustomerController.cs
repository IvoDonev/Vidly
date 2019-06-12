using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private CustomersViewModels _viewModel = new CustomersViewModels()
        {
            Customers = new List<Models.Customer>()
            {
                new Models.Customer() { Name = "Adam", Id = 1},
                new Models.Customer() { Name = "Batman", Id = 2 }
            }
        };

        // GET: Customer
        public ActionResult Index()
        {
            return View(_viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _viewModel.Customers.FirstOrDefault(c => c.Id == id);
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