using DLL.Context;
using DLL.Models;
using DLL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class SessionRepository : BaseRepository<Session>
    {
        public SessionRepository(CinemaContext cinemaContext) : base(cinemaContext)
        {

        }

        public override async Task<IReadOnlyCollection<Session>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Film).Include(x => x.Hall)
               .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Session>> FindByConditionAsync(Expression<Func<Session, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x => x.Film).Include(x => x.Hall).ToListAsync().ConfigureAwait(false);
        }

    }
}
