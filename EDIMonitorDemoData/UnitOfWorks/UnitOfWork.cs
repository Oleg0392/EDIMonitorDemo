using Microsoft.EntityFrameworkCore.ChangeTracking;
using EDIMonitorDemoData.Repositories;
using EDIMonitorDemoData.Repositories.Interfaces;

namespace EDIMonitorDemoData.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<ISentDocRepository> _sentDocRepository;

        public UnitOfWork(
            ApplicationDbContext context,
            Lazy<ISentDocRepository> sentDocRepository
            )
        {
            _context = context;
            _sentDocRepository = sentDocRepository;
        }

        public ISentDocRepository SentDocs => _sentDocRepository.Value;

        public EntityEntry GetContextEntry(object entity)
        {
            return _context.Entry(entity);
        }
    }
}
