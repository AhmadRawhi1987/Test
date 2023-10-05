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
        Task<List<T>> List(Dictionary<string, string> condition = null);
    }
}
