using System;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FluentValidation;

namespace application.Infrastructure.Request
{
	public class RequestDispatcher:IRequestDispatcher
	{
		private readonly IComponentContext _container;
        protected RequestDispatcher() { }

        public RequestDispatcher(IComponentContext container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;

        }

	    public virtual TResult Dispatch<TParameter,TResult>(TParameter request) where TParameter : IRequest where TResult:IRequestResult
	    {
	        var handler = _container.Resolve<IRequestHandler<TParameter, TResult>>();

	        var validator = _container.ResolveOptional<IValidator<TParameter>>();

	        var preprocessor = _container.ResolveOptional<IRequestPreprocessor<TParameter>>();

	        if (validator == null)
	        {
	            preprocessor?.Execute(request);

	            return handler.Execute(request);
	        }

	        var validationResult = validator.Validate(request);

	        if (validationResult.IsValid)
	        {
	            preprocessor?.Execute(request);

	            return handler.Execute(request);
	        }

	        var validationErrorMessage = new StringBuilder();

	        foreach (var failure in validationResult.Errors)
	        {
	            validationErrorMessage.AppendLine(failure.ErrorMessage);
	        }

	        throw new RequestValidationException(validationErrorMessage.ToString());
	    }

        public async Task<TResult> DispatchAsync<TParameter, TResult>(TParameter request) where TParameter : IRequest where TResult : IRequestResult
        {
            var result = await new TaskFactory().StartNew(
                (
                    () => Dispatch<TParameter, TResult>(request))
                );

            return result;
        }

	}
}
