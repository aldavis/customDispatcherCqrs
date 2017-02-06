namespace application.Infrastructure.Request
{
    public interface IRequestValidation<in TParameter> where TParameter : IRequest
    {
        RequestValidationException ValidationError { get; set; }

    }
}