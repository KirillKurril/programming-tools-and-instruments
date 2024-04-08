using Microsoft.EntityFrameworkCore;
using MLWD5.Domain.Abstractions;
using MLWD5.Domain.Entities;
using MLWD5.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistense.Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {

        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;
        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> ListAsync(
            Expression<Func<T, bool>>? filter,
            CancellationToken cancellationToken = default,
            params Expression<Func<T, object>>[] includesProperties)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in
                includesProperties)
                {
                    query = query.Include(included);
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }
        public Task UpdateAsync(T entity,
        CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
