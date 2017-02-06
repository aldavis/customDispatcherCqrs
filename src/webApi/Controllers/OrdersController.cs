using System.Web.Http;
using application.Infrastructure.Request;
using application.Orders.Add;
using application.Orders.Delete;
using application.Orders.Reporting;

namespace webApi.Controllers
{
    [RoutePrefix("api/order")]
    public class OrdersController : ApiController
    {
        readonly IRequestDispatcher _dispatcher;

        public OrdersController(IRequestDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post(AddOrderRequest request)
        {
            var result = _dispatcher.Dispatch<AddOrderRequest, AddOrderResult>(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(DeleteOrderRequest request)
        {
            var result = _dispatcher.Dispatch<DeleteOrderRequest, DeleteOrderResult>(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("totalbycustomer")]
        public IHttpActionResult TotalByCustomer(int customerId)
        {
            var result = _dispatcher.Dispatch<TotalsByCustomerRequest, TotalsByCustomerResult>(new TotalsByCustomerRequest(customerId));

            return Ok(result);
        }
    }
}
