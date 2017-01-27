namespace application.infrastructure
{
    public interface IRequestValidation<in TParameter> where TParameter : IRequest
    {
        RequestValidationException ValidationError { get; set; }

    }
}