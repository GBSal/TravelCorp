using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public class AddToBasketCommand : BasketBase, IAddToBasketCommand
    {

        public AddToBasketResponse Invoke(AddToBasketRequest request)
        {
            var basket = GetBasket();

            request.LineItem.Id = basket.LineItems.MaxOrDefault(li => li.Id) + 1;

            basket.LineItems.Add(request.LineItem);

            SaveBasket(basket);

            return new AddToBasketResponse() { LineItemCount = basket.LineItems.Count };
        }
    }

   public class AddToBasketRequest
   {
       public LineItem LineItem { get; set; }
   }

   public class AddToBasketResponse
   {
       public int LineItemCount { get; set; }
   }
}
