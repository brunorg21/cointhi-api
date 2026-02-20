using Cointhi.Api.Database.Repositories;
using Cointhi.Api.Database.Repositories.Transaction;
using Cointhi.Api.Database.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace Cointhi.Api.Database
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Connection")!;

            services.AddDbContext<CointhiDbContext>(options =>
                options.UseSqlite(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }
    }
}
