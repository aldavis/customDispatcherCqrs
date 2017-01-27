using application.infrastructure;

namespace application.Orders.Delete
{
    public class RefundCustomerResult : IRequestResult
    {
        public decimal RefundAmount { get; set; }

    }
}
