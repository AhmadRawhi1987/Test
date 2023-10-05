using Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ReadRepositoryApi<T> : IReadRepositoryApi<T> where T : class
    {

        public Task<T> FirstOrDefaultAsync(Dictionary<string,string> condition = null)
        {
            
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAsync(Dictionary<string, string> condition = null)
        {
            throw new NotImplementedException();
        }
    }
}
