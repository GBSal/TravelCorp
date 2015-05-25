using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
   public class LineItem
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Amount { get; set; }

        public decimal Discount { get; set; }

        public string OfferDiscription { get; set; }

        public OffersBase Offer { get; set; }

        public bool DiscountApplied { get; set; }
    }   
}
