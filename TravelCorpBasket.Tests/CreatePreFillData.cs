using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelCorp.domain;
using System.IO;

namespace TravelCorpBasket.Tests
{
    /// <summary>
    /// Summary description for CreatePreFillData
    /// </summary>
    [TestClass]
    public class CreatePreFillData
    {

        [TestMethod]
        public void CreateOffersData()
        {

            var offers = new Dictionary<string, OffersBase>
            {
                {"BuyThreeMilkGetFourthMilkFree", new BuyThreeGetFourthFree{ DiscountPercentage = 100 }},
                {"Buy2ButterGetBreadAt50%", new BuyTwoGetThirdAtHalf{ DiscountPercentage = 50 }},

            };


            var ser = SerializationHelper.DataContractSerialize(offers);

            using (var fileWriter = new StreamWriter(@"..\..\..\TravelCorpBasket.Web\App_Data\offers.xml", false))
            {
                fileWriter.Write(ser);
            }


        }




    }
}
