using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TravelCorp.domain;

namespace TravelCorp.domain
{
    public abstract class BasketBase
    {
        const string file = @"App_Data\basket.xml";

        string  path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);


        protected Basket GetBasket()
        {
            if (!File.Exists(path))
                return new Basket { LineItems = new List<LineItem>(), };

            using (var sr = new StreamReader(path))
            {
                return SerializationHelper.DataContractDeserialize<Basket>(sr.ReadToEnd());
            }
        }

        protected void SaveBasket(Basket basket)
        {
            using (var sw = new StreamWriter(path, false))
            {
                sw.Write(SerializationHelper.DataContractSerialize(basket));
            }
        }


    }
}
