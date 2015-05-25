using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TravelCorp.domain
{
    public class GetSaleOffersQuery : IGetSaleOffersQuery
    {
        public GetOfferOptionsResponse Invoke(GetOfferOptionsRequest request)
        {
            using (var sr = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\offers.xml")))
            {
                var ser = sr.ReadToEnd();
                var response = new GetOfferOptionsResponse()
                {
                    OffersOptions =
                        SerializationHelper.
                        DataContractDeserialize<Dictionary<string, OffersBase>>(ser)
                };

                return response;
            }
        }
    }

    public class GetOfferOptionsResponse
    {
        public Dictionary<string, OffersBase> OffersOptions { get; set; }
    }

    public class GetOfferOptionsRequest
    {
    }
}
