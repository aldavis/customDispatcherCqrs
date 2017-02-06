using application.Infrastructure.Request;

namespace application.Orders.Reporting
{
    public class TotalsByCustomerRequest :IRequest
    {
        public TotalsByCustomerRequest(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }

    }
}
