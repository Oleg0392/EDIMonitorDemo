using Microsoft.EntityFrameworkCore.ChangeTracking;
using EDIMonitorDemoData.Repositories.Interfaces;

namespace EDIMonitorDemoData.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ISentDocRepository SentDocs { get; }

        EntityEntry GetContextEntry(object entity);
    }
}
