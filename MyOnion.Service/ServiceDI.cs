using Microsoft.Extensions.DependencyInjection;

namespace MyOnion.Service
{
    public static class ServiceDI
    {
        public static void ServiceDependency(this IServiceCollection service)
        {
            service.AddScoped<IBookService, BookService>();
        }
    }
}
