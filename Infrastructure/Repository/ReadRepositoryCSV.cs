using Application.Repository;
using Domain.Makes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ReadRepositoryCSV<T> : IReadRepositoryCSV<T> where T : class
    {
        public async Task<T> FirstOrDefaultAsync(Dictionary<string, string> condition = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ListAsync(Dictionary<string, string> condition = null)
        {
            throw new NotImplementedException();
        }
    }
}
