using TheaterTicketsManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheaterTickets.API
{
    public static class ServicesExtensionMethods
    {
        public static void ConfigureSqlDbContext( this IServiceCollection services, IConfiguration config)
        {

            string connectionString = config.GetConnectionString("sqlConnectionString");
            services.AddDbContext<TheaterDbContext>(server => server.UseSqlServer(connectionString, b => b.MigrationsAssembly("TheaterTickets.API")));
        }
    }
}
