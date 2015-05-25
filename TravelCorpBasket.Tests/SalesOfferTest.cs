using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using TravelCorp.domain;
using TravelCorp.domain.Fakes;

namespace TravelCorpBasket.Tests
{

    [TestClass]
    public class SalesOfferTest
    {

        const string Bread = "Bread";
        const decimal BreadCost = 1.00M;

        const string Butter = "Butter";
        const decimal ButterCost = 0.80M;

        const string Milk = "Milk";
        const decimal MilkCost = 1.15M;

        const decimal FiftyPercent = 50;

        const decimal HundredPercent = 100;



        public SalesOfferTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        [TestMethod]
        public void WhenBasketHasOneBreadOneButterOneMilk_ThenBasketShowsRequiredTotal()
        {

            decimal total = 2.95M;

            var lineItems = new List<LineItem> { 

                new LineItem{Id = 1, ProductId=(int)Product.Butter, ProductName = Butter, Amount = ButterCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                new LineItem{ Id = 2,ProductId=(int)Product.Bread, ProductName = Bread, Amount = BreadCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                new LineItem{Id = 3, ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
            };

            var basket = new StubBasket { LineItems = lineItems };

            var saleOfferCalculator = new SaleOfferCalculator();

            basket.BasketTotal = saleOfferCalculator.CalculateOffers(basket);


            Assert.AreEqual(basket.BasketTotal, total);



        }

        [TestMethod]
        public void WhenBasketTwoButterTwoBread_ThenBasketShowsRequriedTotal()
        {

            decimal total = 3.10M;

            var lineItems = new List<LineItem> { 

                new LineItem{ Id = 1,ProductId=(int)Product.Butter, ProductName = Butter, Amount = ButterCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                new LineItem{ Id = 2,ProductId=(int)Product.Butter, ProductName = Butter, Amount = ButterCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                new LineItem{ Id = 3,ProductId=(int)Product.Bread, ProductName = Bread, Amount = BreadCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                new LineItem{ Id = 4,ProductId=(int)Product.Bread, ProductName = Bread, Amount = BreadCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                
            };

            var basket = new StubBasket { LineItems = lineItems };

            var saleOfferCalculator = new SaleOfferCalculator();

            basket.BasketTotal = saleOfferCalculator.CalculateOffers(basket);

            Assert.AreEqual(basket.BasketTotal, total);



        }

        [TestMethod]
        public void WhenBasketHasFourMilk_ThenBasketShowsRequiredTotal()
        {

            decimal total = 3.45M;

            var lineItems = new List<LineItem> { 

                 new LineItem{ Id = 1,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 2,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 3,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 4,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}}
            };

            var basket = new StubBasket { LineItems = lineItems };

            var saleOfferCalculator = new SaleOfferCalculator();

            basket.BasketTotal = saleOfferCalculator.CalculateOffers(basket);


            Assert.AreEqual(basket.BasketTotal, total);

        }

        [TestMethod]
        public void WhenBasketHasTwoButterOneBreadAndEightMilk_ThenBasketShowsRequiredTotal()
        {

            decimal total = 9.00M;

            var lineItems = new List<LineItem> { 

                 new LineItem{ Id = 1,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 2,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 3,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 4,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},

                new LineItem{Id = 5, ProductId=(int)Product.Butter, ProductName = Butter, Amount = ButterCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                new LineItem{ Id = 6,ProductId=(int)Product.Butter, ProductName = Butter, Amount = ButterCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},
                new LineItem{ Id = 7,ProductId=(int)Product.Bread, ProductName = Bread, Amount = BreadCost,Offer = new BuyTwoGetThirdAtHalf{DiscountPercentage=FiftyPercent}},

                    
                 new LineItem{ Id = 8,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 9,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 10,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}},
                 new LineItem{ Id = 11,ProductId=(int)Product.Milk, ProductName = Milk, Amount = MilkCost,Offer = new BuyThreeGetFourthFree{DiscountPercentage=HundredPercent}}

            };

            var basket = new StubBasket { LineItems = lineItems };

            var saleOfferCalculator = new SaleOfferCalculator();

            basket.BasketTotal = saleOfferCalculator.CalculateOffers(basket);


            Assert.AreEqual(basket.BasketTotal, total);



        }

    }
}
