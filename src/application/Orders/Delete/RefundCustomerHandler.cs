using System;
using application.infrastructure;

namespace application.Orders.Delete
{
    public class RefundCustomerHandler : RequestHandler,IRequestHandler<RefundCustomerRequest, RefundCustomerResult>
    {
        public RefundCustomerResult Execute(RefundCustomerRequest request)
        {
            //do some logic to get the customers money refunded

            return new RefundCustomerResult();
        }
    }
}
