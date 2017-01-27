namespace application.infrastructure
{
	public class RequestHandler
	{
		public RequestValidationException ValidationError { get; set; }
		public RequestExecutionException ExecutionError { get; set; } 
	}
}
