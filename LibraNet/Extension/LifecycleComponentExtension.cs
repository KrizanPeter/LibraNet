using LibraNet.Contracts.Repositories;
using LibraNet.Contracts.Services;
using LibraNet.Domain.Repositories;
using LibraNet.Services.Services;

namespace LibraNet.Api.Modules
{
    public static class LifecycleComponentExtension
    {
        public static IServiceCollection AddLifecycleComponentModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowingService, BorrowingService>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBorrowingRepository, BorrowingRepository>();
            services.AddScoped<IEmailNotificationService, EmailNotificationService>();

            return services;
        }
    }
}
