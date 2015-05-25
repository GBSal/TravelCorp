using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelCorpBasket.Web.Models
{
    public class LineItemViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Amount { get; set; }

        public string OfferDescription { get; set; }

        public string OffersOption { get; set; }

    }
}