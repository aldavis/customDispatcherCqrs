using System;
using System.Linq;
using application.Infrastructure.Persistence;
using application.Infrastructure.Request;
using domain.Model;
using FluentValidation;

namespace application.Orders.Add
{
    public class AddOrderRequest : IRequest
    {
        public AddOrderRequest(int customerId, string partNumber, int quantity)
        {
            CustomerId = customerId;
            PartNumber = partNumber;
            Quantity = quantity;
        }

        public int CustomerId { get; }
        public string PartNumber { get; }
        public int Quantity { get; }

    }

    public class AddOrderResult : IRequestResult
    {
        public string OrderNumber { get; set; }

        public DateTime ExpectedShipDate { get; set; }

    }

    public class AddOrderValidator : AbstractValidator<AddOrderRequest>
    {
        private readonly IEntityFrameworkContext _context;

        public AddOrderValidator(IEntityFrameworkContext context)
        {
            _context = context;

            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer # not supplied");
            RuleFor(x => x.PartNumber).NotEmpty().WithMessage("Part # not supplied");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");

            RuleFor(x => x.PartNumber).Must(ProductMustExist).WithMessage("Supplied Part # does not exist");
            RuleFor(x => x.CustomerId).Must(CustomerMustExist).WithMessage("Supplied CustomerId does not exist");
        }

        private bool ProductMustExist(string partNumber)
        {
            return _context.Products.Any(x => x.PartNumber == partNumber);
        }

        private bool CustomerMustExist(int customerId)
        {
            return _context.Customers.Any(x => x.Id == customerId);
        }
    }

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
