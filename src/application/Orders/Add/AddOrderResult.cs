using System;
using application.infrastructure;

namespace application.Orders.Add
{
    public class AddOrderResult:IRequestResult
    {
        public string OrderNumber { get; set; }

        public DateTime ExpectedShipDate { get; set; }

    }
}
