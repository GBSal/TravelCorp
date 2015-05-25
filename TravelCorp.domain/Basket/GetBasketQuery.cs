using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public class GetBasketQuery : BasketBase, IGetBasketQuery
    {
        private readonly ISaleOfferCalculator _offersCalculator;

        public GetBasketQuery(ISaleOfferCalculator offersCalculator)
        {
            _offersCalculator = offersCalculator;
        }


        public Basket Invoke(BasketRequest request)
        {
            var basket = GetBasket();

            basket.BasketTotal = basket.LineItems.Sum(x => x.Amount);

            return basket;
        }
    }



}
