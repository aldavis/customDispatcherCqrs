using application.infrastructure;

namespace application.Orders.Delete
{
    public class CancelOrderShippingResult : IRequestResult
    {
        public string OrderNumber { get; set; }

    }
}
