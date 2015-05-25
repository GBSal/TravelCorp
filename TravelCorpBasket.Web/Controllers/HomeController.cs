using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelCorp.domain;
using TravelCorpBasket.Web.Models;

namespace TravelCorpBasket.Web.Controllers
{
    public class HomeController : Controller
    {

        IGetSaleOffersQuery _saleOptions;
        IAddToBasketCommand _addToBasket;
        ISaveBasketCommand _saveBasket;
        IGetBasketQuery _basketQuery;
        ISaleOfferCalculator _offersCalculator;
        IRemoveFromBasketCommand _removeBasket;

        public HomeController
                (
                IGetSaleOffersQuery saleOptions,
                IAddToBasketCommand addToBasket,
                ISaveBasketCommand saveBasket,
                IGetBasketQuery basketQuery,
                ISaleOfferCalculator offersCalculator,
                IRemoveFromBasketCommand removeBasket
                )
        {



            _saleOptions = saleOptions;
            _addToBasket = addToBasket;
            _saveBasket = saveBasket;
            _basketQuery = basketQuery;
            _offersCalculator = offersCalculator;
            _removeBasket = removeBasket;
        }


        public ActionResult Index()
        {
         


            var offers = _saleOptions.Invoke(new GetOfferOptionsRequest()).OffersOptions;
            var basket = _basketQuery.Invoke(new BasketRequest());


            var viewModel = new BasketViewModel { OfferOptions = offers, Basket = basket };

            return View(viewModel);
        }

        public ActionResult ApplyDiscount()
        {
         
            var basket = _basketQuery.Invoke(new BasketRequest());

            basket.BasketTotal = _offersCalculator.CalculateOffers(basket);

            _saveBasket.Invoke(basket);

            return RedirectToAction("Index");

        }


        public ActionResult AddItem(LineItemViewModel lineItemViewModel)
        {
           
            var offerOptions = _saleOptions.Invoke(new GetOfferOptionsRequest()).OffersOptions;

            var lineItem = new LineItem
            {
                ProductId = lineItemViewModel.ProductId,
                ProductName = lineItemViewModel.ProductName,
                Amount = lineItemViewModel.Amount,

                Offer = offerOptions[lineItemViewModel.OffersOption]


            };


            var repsonse = _addToBasket.Invoke(new AddToBasketRequest() { LineItem = lineItem });

            return RedirectToAction("Index");
        }


        public ActionResult RemoveItem(int id)
        {
          
            _removeBasket.Invoke(id);

            return RedirectToAction("Index");
        }
    }
}