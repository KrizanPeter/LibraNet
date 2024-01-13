using LibraNet.Contracts.Services;
using LibraNet.Services.Services;

namespace LibraNet.Api.Modules
{
    public static class LifecycleComponentExtension
    {
        public static IServiceCollection AddLifecycleComponentModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowingService, BorrowingService>();

            return services;
        }
    }
}
