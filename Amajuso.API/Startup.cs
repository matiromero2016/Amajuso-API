using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amajuso.API.Configure;
using Amajuso.API.Services;
using Amajuso.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Amajuso.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // services.AddDbContext<DefaultContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<DefaultContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")), ServiceLifetime.Scoped);
            //services.AddScoped<DefaultContext, DefaultContext>();
            services.AddCustomCors();
            services.AddCustomDependency(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddHttpClient();
            services.AddHostedService<YoutubeServiceBackground>();

            services.AddMvc(b =>
            {
                b.EnableEndpointRouting = false;
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();
        }
    }
}
