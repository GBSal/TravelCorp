﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public class Basket
    {
        public List<LineItem> LineItems { get; set; }
        public decimal BasketTotal { get; set; }



    }
}
