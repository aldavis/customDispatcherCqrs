using System.Linq;
using application.Infrastructure.Persistence;
using FluentValidation;

namespace application.Orders.Add
{
    public class AddOrderValidator:AbstractValidator<AddOrderRequest>
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
}
