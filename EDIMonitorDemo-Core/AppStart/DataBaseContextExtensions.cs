using EDIMonitorDemoData;
using Microsoft.EntityFrameworkCore;

namespace EDIMonitorDemoCore.AppStart
{
    public static class DataBaseContextExtensions
    {
        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
