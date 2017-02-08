namespace application.Infrastructure.Request
{
    public interface IRequestPreprocessor<in TParameter> where TParameter : IRequest
    {
        void Execute(TParameter request);
    }
}