using Application.Repository;
using CsvHelper;
using Domain.Makes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.Repository
{
    public class ReadRepositoryCSV<T> : IReadRepositoryCSV<T> where T : class
    {
        public async Task<T> FirstOrDefault(string fileName, Expression<Func<T, bool>> condition = null)
        {
            var sPath = Directory.GetCurrentDirectory() + @"\CSV\" + fileName;
            IQueryable<T> query;
            T result;
            using (var reader = new StreamReader(sPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    query = csv.GetRecords<T>().AsQueryable();
                    if (condition != null)
                    {
                        query = query.Where(condition);
                    }
                    result = query.FirstOrDefault();
                }
            }
            
            return result;
        }

        public async Task<List<T>> List(string fileName, Expression<Func<T, bool>> condition = null)
        {
            var sPath = Directory.GetCurrentDirectory() + @"\CSV\" + fileName;
            IQueryable<T> query;
            List<T> result;
            using (var reader = new StreamReader(sPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    query = csv.GetRecords<T>().AsQueryable();
                    if (condition != null)
                    {
                        query = query.Where(condition);
                    }
                    result = query.ToList();
                }
            }

            return result;
        }
    }
}
