using LibraNet.Domain.LibraContext;
using LibraNet.Services.AutoMapperProfiles;
using LibraNet.Services.BackgroundServices;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraNet.Api.Extension
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServicesModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddHostedService<EmailSenderBackgroundService>();

            services.AddDbContext<LibraDbContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                string connStr;

                if (env == "Development")
                {
                    connStr = config.GetConnectionString("DefaultConnection");
                    options.UseSqlite(connStr);
                }
                else
                {
                    //Some another envs
                }
            });

            return services;
        }
    }
}
