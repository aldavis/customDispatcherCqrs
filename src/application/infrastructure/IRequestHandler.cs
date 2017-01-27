namespace application.infrastructure
{
	public interface IRequestHandler<in TParameter,out TResult> where TParameter : IRequest where TResult:IRequestResult
	{
		
		RequestExecutionException ExecutionError { get; set; }

        TResult Execute(TParameter request);

	}
}