using Microsoft.EntityFrameworkCore;
using EDIMonitorDemoData.Models;

namespace EDIMonitorDemoData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<SentDocument> U_CHEDISENTDOC { get; set; }

    }
}