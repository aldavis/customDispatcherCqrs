using System;

namespace application.infrastructure
{
    public class RequestExecutionException:Exception
    {
        public RequestExecutionException(string message): base(message)
        {
            
        }
    }
}
