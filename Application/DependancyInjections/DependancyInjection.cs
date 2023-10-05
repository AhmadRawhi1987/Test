using Application.MakeServices;
using Application.ModelsServices;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependancyInjections
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            ////////////////Mapping 
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
            ////////////////End Mapping
            services.AddScoped<IMakeService, MakeService>();
            services.AddScoped<IModelsService, ModelsService>();
            return services;
        }
    }
}
