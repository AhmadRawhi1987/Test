using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IReadRepositoryApi<T> where T : class
    {
        Task<T> FirstOrDefaultAsync(Dictionary<string, string> condition = null);
        Task<List<T>> ListAsync(Dictionary<string, string> condition = null);
    }
}
