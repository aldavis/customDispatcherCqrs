using System;
using application.Infrastructure.Request;

namespace application.Orders.Add
{
    public class AddOrderResult:IRequestResult
    {
        public string OrderNumber { get; set; }

        public DateTime ExpectedShipDate { get; set; }

    }
}
