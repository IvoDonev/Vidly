using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DTOs;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        // GET: Returns
        public ActionResult Returns(int id = -1)
        {
            var initCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (initCustomer != null)
            {
                return View(new ReturnsViewModel()
                {
                    HasInitCustomer = id >= 0,
                    InitCustomer = AutoMapper.Mapper.Map<Customer, CustomerDto>(initCustomer)
                });
            }
            else
            return View(new ReturnsViewModel() { HasInitCustomer = false });
        }
    }
}