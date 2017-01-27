using application.infrastructure;

namespace application.Orders.Delete
{
    public class CancelOrderShippingRequest : IRequest
    {
        public CancelOrderShippingRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
