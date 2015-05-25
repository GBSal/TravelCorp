using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    [KnownType("KnownTypes")]
    public abstract class OffersBase
    {

        public static IEnumerable<Type> KnownTypes()
        {
            return new[] { typeof(BuyTwoGetThirdAtHalf), typeof(BuyThreeGetFourthFree) };
        }


        public abstract decimal DiscountPercentage { get; set; }

        public abstract string GetDescription(LineItem lineItem, Basket basket);

        public abstract decimal GetAmount(LineItem lineItem, Basket basket);

    }
}
