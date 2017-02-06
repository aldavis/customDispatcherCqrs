using application.Infrastructure.Request;

namespace application.Orders.Delete
{
    public class DeleteOrderRequest:IRequest
    {
        public DeleteOrderRequest(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
