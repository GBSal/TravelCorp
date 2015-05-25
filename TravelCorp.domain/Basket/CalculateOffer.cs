using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public class SaleOfferCalculator : ISaleOfferCalculator
    {
        public decimal CalculateOffers(Basket basket)
        {
            foreach (var item in basket.LineItems)
            {

                item.Amount = item.Offer.GetAmount(item, basket);

                
            }

            return basket.LineItems.Sum(x => x.Amount);
        }
    }
}
