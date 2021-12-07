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
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(CinemaContext cinemaContext) : base(cinemaContext)
        {
        }

        public override async Task<IReadOnlyCollection<Employee>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Login).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Employee>> FindByConditionAsync(Expression<Func<Employee, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x => x.Login).ToListAsync().ConfigureAwait(false);
        }
    }
}
