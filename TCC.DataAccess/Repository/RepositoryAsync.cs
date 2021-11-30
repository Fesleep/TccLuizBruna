using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TCC.DataAccess.Data;
using TCC.DataAccess.Repository.IRepository;

namespace TCC.DataAccess.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public RepositoryAsync(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            entity.GetType().GetProperty("DataCriacao").SetValue(entity, DateTime.Now, null);
            entity.GetType().GetProperty("Deletado").SetValue(entity, false, null);
            await dbSet.AddAsync(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
            IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(int id)
        {
            T entity = await dbSet.FindAsync(id);
            entity.GetType().GetProperty("DataAtualizacao").SetValue(entity, DateTime.Now, null);
            entity.GetType().GetProperty("Deletado").SetValue(entity, true, null);
            await RemoveAsync(entity);
        }

        public async Task RemoveAsync(T entity)
        {
            entity.GetType().GetProperty("DataAtualizacao").SetValue(entity, DateTime.Now, null);
            entity.GetType().GetProperty("Deletado").SetValue(entity, true, null);
            dbSet.Update(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entity)
        {
            foreach (var i in entity)
            {
                i.GetType().GetProperty("DataAtualizacao").SetValue(i, DateTime.Now, null);
                i.GetType().GetProperty("Deletado").SetValue(i, true, null);
            }
            dbSet.RemoveRange(entity);
        }
    }
}
