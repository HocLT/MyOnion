using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyOnion.Repository
{
    public static class RepositoryDI
    {
        public static void RepoDependency(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<BookDbContext>(o => o.UseSqlServer(
                config.GetConnectionString("BookDbConnection"),
                s=>s.MigrationsAssembly(typeof(BookDbContext).Assembly.FullName))
            );

            service.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
