using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelCorp.domain;

namespace TravelCorpBasket.Web.Models
{
    public class BasketViewModel
    {
        public Basket Basket { get; set; }
        public Dictionary<string, OffersBase> OfferOptions { get; set; }
    }
}