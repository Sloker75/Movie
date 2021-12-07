using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public interface IReposiory<T>
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<IReadOnlyCollection<T>> FindByConditionAsync(Expression<Func<T, bool>> predicat);
        Task CreateAsync(T item);
    }
}
