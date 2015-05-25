using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCorp.domain
{
   public interface IUnitOfWork<TRequest,TResponse>
    {
       TResponse Invoke(TRequest request);

    }
}
