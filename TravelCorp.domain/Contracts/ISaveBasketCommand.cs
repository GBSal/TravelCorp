using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
    public interface ISaveBasketCommand : ICommand<Basket, SaveBasketResponse> { }
}
