using application.Infrastructure.Persistence;
using application.Infrastructure.Request;
using domain.Model;
using FluentValidation;

namespace application.Products
{
    public class AddProductRequest:IRequest
    {

        public AddProductRequest(string partNumber, decimal price)
        {
            PartNumber = partNumber;
            Price = price;
        }

        public string PartNumber { get; }

        public decimal Price { get; }
    }

    public class AddProductResult : IRequestResult
    {
        public int ProductId { get; set; }

        public string Message { get; set; }
    }

    public class AddProductValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.PartNumber).NotEmpty().WithMessage("Part number must be supplied");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price cannot be 0");
        }
    }

    public class AddProductPreprocessor : IRequestPreprocessor<AddProductRequest>
    {
        public void Execute(AddProductRequest request)
        {
            //do some logic before the handler runs
            string foo = request.PartNumber;
        }
    }

    public class AddProductHandler:RequestHandler,IRequestHandler<AddProductRequest,AddProductResult>
    {
        private readonly IEntityFrameworkContext _context;

        public AddProductHandler(IEntityFrameworkContext context)
        {
            _context = context;
        }

        public AddProductResult Execute(AddProductRequest request)
        {
            var product = new Product
            {
                PartNumber = request.PartNumber,
                Price = request.Price
            };

            _context.Products.Add(product);

            _context.SaveChanges();

            return new AddProductResult
            {
                Message = $"Part Number {request.PartNumber} added with Product Id of {product.Id}",
                ProductId = product.Id
            };
        }
    }
}
