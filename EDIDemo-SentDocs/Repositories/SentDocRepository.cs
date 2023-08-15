using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EDIMonitorDemoData.Repositories.Interfaces;
using EDIMonitorDemoData.Models;

namespace EDIMonitorDemoData.Repositories
{
    public class SentDocRepository : RepositoryBase<SentDocument>, ISentDocRepository 
    {
        private readonly ApplicationDbContext _context;

        public SentDocRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SentDocument> GetAllSentDocs()
        {
            return await _context.U_CHEDISENTDOC.FirstOrDefaultAsync();
        }

        public async Task<SentDocument[]> GetSentDocsWhere(Expression<Func<SentDocument, bool>> match)
        {
            return await _context.U_CHEDISENTDOC.Where(match).OrderBy(sd => sd.DtVrOtpr).ToArrayAsync();
        }

        public async Task<SentDocument> GetSentDocById(long IsproDoc)
        {
            return await _context.U_CHEDISENTDOC.Where(sd => sd.IsProDoc == IsproDoc).FirstOrDefaultAsync();
        }
    }
}
