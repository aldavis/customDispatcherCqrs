using application.Infrastructure.Request;

namespace application.Orders.Delete
{
    public class RefundCustomerResult : IRequestResult
    {
        public decimal RefundAmount { get; set; }

    }
}
