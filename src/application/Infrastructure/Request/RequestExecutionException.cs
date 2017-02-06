using System;

namespace application.Infrastructure.Request
{
    public class RequestExecutionException:Exception
    {
        public RequestExecutionException(string message): base(message)
        {
            
        }
    }
}
