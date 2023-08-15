using System.Linq.Expressions;

namespace EDIMonitorDemoData.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity[]> GetWhereAsync(Expression<Func<TEntity, bool>> match);

        Task<TEntity> UpdateAsync(TEntity entityToUpdate);

        Task<TEntity> InsertAsync(TEntity entity);

        Task Delete(TEntity entity);
    }
}
