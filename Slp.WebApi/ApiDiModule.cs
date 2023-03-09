using Autofac;

namespace Slp.WebApi
{
    public class ApiDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ServicesRegister(builder);
            RepositoriesRegister(builder);
            UnitOfWorkRegister(builder);      
            //autofac register transient default lifetime
        }

        private void ServicesRegister(ContainerBuilder builder)
        {
            var servicesAssembly = typeof(Services.AssemblyRunner).Assembly;            
            builder.RegisterAssemblyTypes(servicesAssembly)
                .Where(t => t.GetInterfaces().Contains(typeof(Services.IServiceRegistrator)))
                .AsImplementedInterfaces();
        }

        private void RepositoriesRegister(ContainerBuilder builder)
        {
            var dataAssembly = typeof(DataProvider.AssemblyRunner).Assembly;            
            builder.RegisterAssemblyTypes(dataAssembly)
                .Where(t => t.GetInterfaces().Contains(typeof(DataProvider.IRepositoryRegistrator)))
                .AsImplementedInterfaces();
        }

        private void UnitOfWorkRegister(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(DataProvider.UnitOfWork))
                .As(typeof(DataProvider.IUnitOfWork));
        }
    }
}
