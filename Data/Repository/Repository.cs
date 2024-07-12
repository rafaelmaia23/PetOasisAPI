using Microsoft.EntityFrameworkCore;
using PetOasisAPI.Data.Repository.IRepository;
using System.Linq.Expressions;

namespace PetOasisAPI.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        protected DbSet<T> dbSet;
        protected Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            this.dbSet = _appDbContext.Set<T>();
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>?> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
