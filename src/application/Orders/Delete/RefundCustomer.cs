using System;
using application.Infrastructure.Request;

namespace application.Orders.Delete
{
    public class RefundCustomerRequest : IRequest
    {
        public RefundCustomerRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }

    public class RefundCustomerResult : IRequestResult
    {
        public decimal RefundAmount { get; set; }

    }

    public class RefundCustomerHandler : RequestHandler,IRequestHandler<RefundCustomerRequest, RefundCustomerResult>
    {
        public RefundCustomerResult Execute(RefundCustomerRequest request)
        {
            //do some logic to get the customers money refunded

            return new RefundCustomerResult();
        }
    }
}
