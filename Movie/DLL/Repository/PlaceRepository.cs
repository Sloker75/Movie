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
    public class PlaceRepository : BaseRepository<Place>
    {
        public PlaceRepository(CinemaContext cinemaContext) : base(cinemaContext)
        {

        }

        public override async Task<IReadOnlyCollection<Place>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Hall).Include(x => x.Booking).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Place>> FindByConditionAsync(Expression<Func<Place, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x => x.Hall).Include(x => x.Booking).ToListAsync().ConfigureAwait(false);
        }


    }
}
