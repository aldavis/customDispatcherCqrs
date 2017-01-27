using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace application
{
    public class ApplicationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}
