using application.Infrastructure.Request;

namespace application.Orders.Add
{
    public class AddOrderRequest :IRequest
    {
        public AddOrderRequest(int customerId, string partNumber,int quantity)
        {
            CustomerId = customerId;
            PartNumber = partNumber;
            Quantity = quantity;
        }

        public int CustomerId { get; }
        public string PartNumber { get; }
        public int Quantity { get; }


    }
}
