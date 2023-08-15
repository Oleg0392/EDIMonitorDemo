using System.Linq.Expressions;
using EDIMonitorDemoData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace EDIMonitorDemoData.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;

        private readonly DbSet<TEntity> dbSet;

        protected RepositoryBase(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity[]> GetWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await context.Set<TEntity>().Where(match).ToArrayAsync();
        }
        
        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                if (context.Entry(entityToUpdate).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToUpdate);
                }

                context.Entry(entityToUpdate).State = EntityState.Modified;
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                await context.SaveChangesAsync();

                return entityToUpdate;
            }
            catch (Exception e)
            {
                throw new /*Repository*/Exception(e.Message/*, e.InnerException, typeof(TEntity).ToString()*/);
            }
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
