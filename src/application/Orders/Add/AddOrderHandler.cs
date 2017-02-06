using System;
using System.Linq;
using application.Infrastructure.Persistence;
using application.Infrastructure.Request;
using domain.Model;

namespace application.Orders.Add
{
    public class AddOrderHandler:RequestHandler,IRequestHandler<AddOrderRequest,AddOrderResult>
    {
        private readonly IEntityFrameworkContext _context;

        public AddOrderHandler(IEntityFrameworkContext context)
        {
            _context = context;
        }

        public AddOrderResult Execute(AddOrderRequest request)
        {
            var result = new AddOrderResult();

            var customer = _context.Customers.Find(request.CustomerId);
            var product = _context.Products.First(x => x.PartNumber == request.PartNumber);


            if (product.Available(request.Quantity) || product.CanFulfillBackOrder(request.Quantity))
            {
                result.ExpectedShipDate = DateTime.Now.AddDays(15);
            }
            else
            {
                result.ExpectedShipDate = DateTime.Now.AddDays(60);
            }


            _context.Orders.Add(new Order
            {
                Customer = customer,
                Product = product,
                Quantity = request.Quantity
            });

            _context.SaveChanges();

            return result;
        }
    }
}
