using System;

namespace application.infrastructure
{
    public class RequestValidationException:Exception
    {
        public RequestValidationException(string message):base(message)
        {
            
        }
    }
}
