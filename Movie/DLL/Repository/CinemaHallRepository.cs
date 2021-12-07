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
    public class CinemaHallRepository : BaseRepository<CinemaHall>
    {
        public CinemaHallRepository(CinemaContext cinemaContext) : base(cinemaContext)
        {

        }

        public override async Task<IReadOnlyCollection<CinemaHall>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Sessions).Include(x => x.Place)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<CinemaHall>> FindByConditionAsync(Expression<Func<CinemaHall, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x => x.Sessions).Include(x => x.Place)
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
