namespace application.Infrastructure.Request
{
	public class RequestHandler
	{
		public RequestValidationException ValidationError { get; set; }
		public RequestExecutionException ExecutionError { get; set; } 
	}
}
