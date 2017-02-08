using System.Web.Http;
using application.Infrastructure.Request;
using application.Orders.Add;
using application.Orders.Delete;
using application.Orders.Reporting;
using application.Products;

namespace webApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductsController : ApiController
    {
        readonly IRequestDispatcher _dispatcher;

        public ProductsController(IRequestDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post(AddProductRequest request)
        {
            var result = _dispatcher.Dispatch<AddProductRequest, AddProductResult>(request);

            return Ok(result);
        }
    }
}
