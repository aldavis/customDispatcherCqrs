using System;
using application.infrastructure;

namespace application.Orders.Delete
{
    public class DeleteOrderResult:IRequestResult
    {
        public string ConfirmationNumber { get; set; }

    }
}
