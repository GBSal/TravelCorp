using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public class SaveBasketCommand : BasketBase, ISaveBasketCommand
    {

        public SaveBasketResponse Invoke(Basket basket)
        {
           SaveBasket(basket);

            return new SaveBasketResponse() { };
        }

    }

    public class SaveBasketResponse
    {
  
    }

}
