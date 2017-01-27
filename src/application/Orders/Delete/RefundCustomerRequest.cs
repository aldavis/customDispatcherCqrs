using application.infrastructure;

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
}
