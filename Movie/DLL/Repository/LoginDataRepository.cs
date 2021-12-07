using DLL.Context;
using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public class LoginDataRepository : BaseRepository<LoginData>
    {
        public LoginDataRepository(CinemaContext cinemaContext) : base(cinemaContext)
        {

        }

        public override async Task<IReadOnlyCollection<LoginData>> FindByConditionAsync(Expression<Func<LoginData, bool>> predicat)
        {
            return await this.Entities.Where(predicat)
                .Include(x => x.Employee)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<LoginData>> GetAllAsync()
        {
            return await this.Entities
                .Include(x => x.Employee)
                .ToListAsync()
                .ConfigureAwait(false);
        }



    }
}
