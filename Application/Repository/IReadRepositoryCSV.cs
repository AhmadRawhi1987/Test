using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IReadRepositoryCSV<T> where T : class
    {
        Task<T> FirstOrDefault(string fileName, Expression<Func<T, bool>> condition = null);
        Task<List<T>> List(string fileName, Expression<Func<T, bool>> condition = null);
    }
}
