using System.Web.Http;
using application.infrastructure;
using application.Orders.Add;

namespace webApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrdersController : ApiController
    {
        readonly IRequestDispatcher _dispatcher;

        public OrdersController(IRequestDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        public IHttpActionResult Post(AddOrderRequest request)
        {
            var result = _dispatcher.Dispatch<AddOrderRequest, AddOrderResult>(request);

            return Ok(result);
        }
    }
}
