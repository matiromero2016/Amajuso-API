using Amajuso.Domain;
using Amajuso.Domain.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace Amajuso.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DefaultContext>
    {
        public DefaultContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Amajuso.API/appsettings.json")
                .Build(); 
            string connectionString = configuration.GetConnectionString("connectionString");
            var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new DefaultContext(optionsBuilder.Options);
        }
    }
}