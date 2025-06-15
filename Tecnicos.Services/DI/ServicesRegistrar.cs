using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Abstractions;
using Tecnicos.Data.DI;

namespace Tecnicos.Services.DI
{
    public static class ServicesRegistrar
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterDbContextFactory();
            services.AddScoped<ITecnicosService, TecnicosServices>();
            return services;
        }
    }
}
