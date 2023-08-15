using Autofac;
using Autofac.Extensions.DependencyInjection;
using EDIMonitorDemoCore.AppStart;

namespace EDIMonitorDemoCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AppModule()));

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCustomDbContext(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();
            app.UseRouting();

            app.Run();
        }
    }
}