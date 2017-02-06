using System;
using application.Infrastructure.Request;

namespace application.Orders.Reporting
{
    public class TotalsByCustomerResult:IRequestResult
    {
        public int TotalUnits { get; set; }

        public string CustomerName { get; set; }

        public string TotalSales { get; set; }

    }
}
