using Amajuso.Domain;
using Amajuso.Domain.Config;
using Amajuso.Domain.Entities;
using Amajuso.Domain.Interfaces;
using Amajuso.Infra.Repository;
using Amajuso.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Amajuso.API.Configure
{
    public static class DependencyService
    {
        public static IServiceCollection AddCustomDependency(this IServiceCollection services, IConfiguration configuration){ 
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IService<User>), typeof(UserService));
            services.AddScoped(typeof(IYoutubeService<Youtube>), typeof(YoutubeService));
            services.AddScoped(typeof(ArticleService), typeof(ArticleService));
            //services.AddScoped(typeof(IService<ArticleCategories>), typeof(BaseService<ArticleCategories>));
            //services.AddScoped(typeof(IService<ArticleCategories>), typeof(ArticleCategoriesService));
            services.AddScoped(typeof(ArticleCategoriesService), typeof(ArticleCategoriesService));
            services.AddTransient(typeof(LoginService), typeof(LoginService));
            services.AddTransient(typeof(TokenService));
            return services;
        }

    } 
}
                // services.AddScoped(typeof(IService<>), typeof(AService<>));

            //     var azureStorage = new AzureStorage();
            // new ConfigureFromConfigurationOptions<AzureStorage>(
            //     configuration.GetSection("AzureStorage"))
            //     .Configure(azureStorage);
            // services.AddSingleton(azureStorage);

            // var clients = new Clients();
            // new ConfigureFromConfigurationOptions<Clients>(
            //     configuration.GetSection("Clients"))
            //     .Configure(clients);
            // services.AddSingleton(clients);

            //get connection string from app settings
            // var database = new Database(); //connection string, va en la carpeta infra
            // new ConfigureFromConfigurationOptions<Database>(
            //     configuration.GetSection("Database"))
            //     .Configure(database);
            // services.AddSingleton(database);

            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
       