using application.infrastructure;

namespace application.Orders.Add
{
    public class AddOrderHandler:RequestHandler,IRequestHandler<AddOrderRequest,AddOrderResult>
    {
        public AddOrderResult Execute(AddOrderRequest request)
        {
            var result = new AddOrderResult();

            //get the customer

            //check if the order can be fulfilled or back ordered

            //set the expected ship date

            return result;
        }
    }
}
