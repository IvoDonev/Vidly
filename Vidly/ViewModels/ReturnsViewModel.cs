using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTOs;

namespace Vidly.ViewModels
{
    public class ReturnsViewModel
    {
        public bool HasInitCustomer { get; set; }
        public CustomerDto InitCustomer { get; set; }
    }
}