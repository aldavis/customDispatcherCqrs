using System;
using application.Infrastructure.Request;

namespace application.Orders.Delete
{
    public class CancelOrderShippingHandler : RequestHandler,IRequestHandler<CancelOrderShippingRequest,CancelOrderShippingResult>
    {
        public CancelOrderShippingResult Execute(CancelOrderShippingRequest request)
        {
            //do some logic to see if the shipping can be stopped

            return new CancelOrderShippingResult();
        }
    }
}
