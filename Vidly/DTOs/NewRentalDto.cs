﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTOs
{
    public class NewRentalDto
    {
        public int CustomerId { get; }
        public List<int> MovieIds { get; }
    }
}