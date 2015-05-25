using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{

    public class RemoveFromBasketCommand : BasketBase, IRemoveFromBasketCommand
    {
        public bool Invoke(int id)
        {
            var basket = GetBasket();

            basket.LineItems.RemoveWhere(li => li.Id == id);

            SaveBasket(basket);

            return true;
        }
    }
}
