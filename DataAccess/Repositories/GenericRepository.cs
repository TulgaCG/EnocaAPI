using DataAccess.Repositories.IRepositories;
using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly DbDataContext _DataContext;
        public GenericRepository(DbDataContext dbd)
        {
            _DataContext = dbd;
        }
        public async Task<TEntity> Add(TEntity model)
        {
            await _DataContext.AddAsync(model);
            await _DataContext.SaveChangesAsync();
            return model;
        }

        public async Task<int> Delete(TEntity model)
        {
            _DataContext.Remove(model);
            return await _DataContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _DataContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _DataContext.Set<TEntity>().ToListAsync() : _DataContext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity model, int id)
        {
            _DataContext.Update(model);
            await _DataContext.SaveChangesAsync();
            return model;
        }
    }
}
