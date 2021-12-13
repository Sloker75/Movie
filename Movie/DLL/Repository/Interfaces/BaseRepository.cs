using DLL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public abstract class BaseRepository<T> : IReposiory<T> where T : class
    {
        protected BaseRepository(CinemaContext cinemaContext)
        {
            context = cinemaContext;
        }

        private DbSet<T> _entities;
        protected CinemaContext context;
        protected DbSet<T> Entities => this._entities ??= context.Set<T>();

        public virtual async Task CreateAsync(T item)
        {
            await Entities.AddAsync(item).ConfigureAwait(false);
            await context.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyCollection<T>> FindByConditionAsync(Expression<Func<T, bool>> predicat)
        {
            return  await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await this.Entities.ToListAsync().ConfigureAwait(false);
        }

        public async Task SaveUpdate()
        {
            await context.SaveChangesAsync();
        }
    }
}
