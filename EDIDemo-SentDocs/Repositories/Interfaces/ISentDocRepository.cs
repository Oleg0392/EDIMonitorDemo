using System.Linq.Expressions;
using EDIMonitorDemoData.Models;

namespace EDIMonitorDemoData.Repositories.Interfaces
{
    public interface ISentDocRepository : IRepositoryBase<SentDocument>
    {
        Task<SentDocument> GetAllSentDocs();

        Task<SentDocument[]> GetSentDocsWhere(Expression<Func<SentDocument, bool>> match);

        Task<SentDocument> GetSentDocById(long IsproDoc);
    }
}
