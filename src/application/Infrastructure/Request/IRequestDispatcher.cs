using System.Threading.Tasks;

namespace application.Infrastructure.Request
{
	public interface IRequestDispatcher
	{
        TResult Dispatch<TParameter, TResult>(TParameter request)where TParameter : IRequest where TResult : IRequestResult;
        Task<TResult> DispatchAsync<TParameter, TResult>(TParameter request) where TParameter : IRequest where TResult:IRequestResult;
	}
} 