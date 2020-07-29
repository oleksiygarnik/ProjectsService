using Agile.DAL.Context;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agile.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
            public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
            {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDatabase")));

            services.AddTransient<DbContext, ApplicationContext>();
            services.AddTransient<IEntityRepository, EntityRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
