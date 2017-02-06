using System;

namespace application.Infrastructure.Request
{
    public class RequestValidationException:Exception
    {
        public RequestValidationException(string message):base(message)
        {
            
        }
    }
}
