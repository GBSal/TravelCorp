using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public class BuyTwoGetThirdAtHalf :OffersBase
    {
        public override decimal DiscountPercentage { get; set; }


        public override string GetDescription(LineItem lineItem, Basket basket)
        {
            return "Buy two get third at half price";
        }

        public override decimal GetAmount(LineItem lineItem, Basket basket)
        {
            var isButter = lineItem.ProductId == (int)Product.Bread;

            if (isButter == true)
            {

                var allButter = (from item in basket.LineItems
                                 where item.Offer.GetType() == typeof(BuyTwoGetThirdAtHalf)
                                                 && item.Id != lineItem.Id
                                                 && item.DiscountApplied == false
                                                 && item.ProductId == (int)Product.Butter
                                 select item).Take(2).ToList();



                if (allButter.Count() == 2)
                {

                    allButter.ForEach((x) => x.DiscountApplied = true);

                    lineItem.DiscountApplied = true;

                    lineItem.Discount = DiscountPercentage;

                    lineItem.OfferDiscription = GetDescription(lineItem, basket);

                    return lineItem.Amount - (lineItem.Amount * DiscountPercentage / 100);
                }
            }

            return lineItem.Amount;
        }
    }
}
