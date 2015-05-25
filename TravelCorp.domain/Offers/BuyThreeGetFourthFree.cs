using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public class BuyThreeGetFourthFree : OffersBase
    {

        public override decimal DiscountPercentage { get; set; }

        public override string GetDescription(LineItem lineItem, Basket basket)
        {
            return "Buy three get fourth free";
        }

        public override decimal GetAmount(LineItem lineItem, Basket basket)
        {

            var itemOtherthanThis = (from item in basket.LineItems
                                     where item.Offer.GetType() == typeof(BuyThreeGetFourthFree)
                                     && item.Id != lineItem.Id
                                     && item.ProductId == item.ProductId
                                     && item.DiscountApplied == false
                                     select item).Take(3).ToList();



            if (itemOtherthanThis.Count() == 3)
            {

                itemOtherthanThis.ForEach((x) => x.DiscountApplied = true);

                lineItem.DiscountApplied = true;

                lineItem.Discount = DiscountPercentage;

                lineItem.OfferDiscription = GetDescription(lineItem, basket);
                    

                
                return lineItem.Amount - (lineItem.Amount * DiscountPercentage / 100);
            }


            return lineItem.Amount;

        }

    }
}
