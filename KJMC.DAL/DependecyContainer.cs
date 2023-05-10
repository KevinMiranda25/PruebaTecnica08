using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using KJMC.EN.Interfaces;
using Microsoft.Extensions.Options;

namespace KJMC.DAL
{
    public static class DependecyContainer
    {
        public static IServiceCollection AddDALDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KJMCDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("conexionKJ")));

            services.AddScoped<IServicio, ServicioDAL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
