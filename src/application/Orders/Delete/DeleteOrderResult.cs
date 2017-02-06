using System;
using application.Infrastructure.Request;

namespace application.Orders.Delete
{
    public class DeleteOrderResult:IRequestResult
    {
        public string ConfirmationNumber { get; set; }

    }
}
