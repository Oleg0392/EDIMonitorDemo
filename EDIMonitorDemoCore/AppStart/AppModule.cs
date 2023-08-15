using System.Reflection;
using Autofac;
using EDIMonitorDemoData.Repositories;
using EDIMonitorDemoData.Repositories.Interfaces;
using Module = Autofac.Module;


namespace EDIMonitorDemoCore.AppStart
{
    public class AppModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            RepositoriesRegister(builder);
        }

        private void RepositoriesRegister(ContainerBuilder builder)
        {
            var dataAssembly = typeof(EDIMonitorDemoData.AssemblyRunner).Assembly;
            builder.RegisterAssemblyTypes(dataAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}
