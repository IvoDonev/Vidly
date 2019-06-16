using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
    
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        // GET: Customer
        public ActionResult Index()
        {
            return View(new CustomersViewModels()
            {
                Customers = _context.Customers.Include("MembershipType").ToList()
            });
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include("MembershipType").FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return HttpNotFound();
            }
        }

        public ActionResult New()
        {
            return View("CustomerForm", new CustomerFormViewModel()
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = new Customer()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", new CustomerFormViewModel()
                {
                    Customer = viewModel.Customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                });
            }


            if (viewModel.Customer.Id == 0)
            {
                // new customer
                _context.Customers.Add(viewModel.Customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                customerInDb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                customerInDb.BirthDate = viewModel.Customer.BirthDate;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                customerInDb.Name = viewModel.Customer.Name;

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include("MembershipType").FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View("CustomerForm", new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                });
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}