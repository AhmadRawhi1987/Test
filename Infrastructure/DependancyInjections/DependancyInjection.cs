using Application.Repository;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependancyInjections
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IReadRepositoryApi<>), typeof(ReadRepositoryApi<>));
            services.AddScoped(typeof(IReadRepositoryCSV<>), typeof(ReadRepositoryCSV<>));
            return services;
        }
    }
}
