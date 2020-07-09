using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amajuso.API.Configure
{
    public static class CorsService
    {
        private static readonly string DefaultPolicy = "DefaultPolicy";

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultPolicy,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(DefaultPolicy);

            return app;
        }
    }
}
