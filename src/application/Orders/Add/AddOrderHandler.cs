using System;
using application.infrastructure;
using domain.Model;

namespace application.Orders.Add
{
    public class AddOrderHandler:RequestHandler,IRequestHandler<AddOrderRequest,AddOrderResult>
    {
        public AddOrderResult Execute(AddOrderRequest request)
        {
            var result = new AddOrderResult();

            //get the customer
            var customer = new Customer {AllowedDiscountAmount = 50};

            //get the product
            var product = new Product
            {
                PartNumber = request.PartNumber,
                InventoryReorderThreshold = 10,
                CurrentInventoryCount = 20,
                OnOrderCount = 100,
                Price = new decimal(253.25)
            };

            //check if the order can be fulfilled or back ordered
            if (product.Available(request.Quantity) || product.CanFulfillBackOrder(request.Quantity))
            {
                result.ExpectedShipDate = DateTime.Now.AddDays(15);
            }
            else
            {
                result.ExpectedShipDate = DateTime.Now.AddDays(60);
            }


            return result;
        }
    }
}
