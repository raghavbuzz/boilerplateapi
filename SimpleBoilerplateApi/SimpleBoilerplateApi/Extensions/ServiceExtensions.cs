using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SimpleBoilerplateApi.Extensions
{
    public static class ServiceExtensions
    {
        // CORS Configuration
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        // IIS Configuration
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        // Logger Configuration
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        // SQL Database Configuration
        // Todo :: Make sure to change the name of Migration Assembly as per project name
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:SqlConnection"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("SimpleBoilerplateApi")));
        }

        // Repository Wrapper Configuration
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        // Swagger Configuration
        public static void ConfigureSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Boilerplate API",
                    Description = "A simple example of ASP.NET Core 3.1 Web API",
                    TermsOfService = new Uri("https://google.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "SopraSteria",
                        Email = string.Empty,
                        Url = new Uri("https://google.com/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under SopraSteria LICX",
                        Url = new Uri("https://google.com"),
                    }
                });

                // Use below for deployment on Windows Server. Comment out in case of Linix or Mac
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });                
        }

        // Health Check Configuration
        public static void ConfigureHealthCheck(this IServiceCollection services, IConfiguration config)
        {
            services.AddHealthChecks().AddSqlServer(config["ConnectionStrings:SqlConnection"],
              healthQuery: "SELECT 1;",
              name: "sql",
              failureStatus: HealthStatus.Degraded,
              tags: new string[] { "db", "sql", "sqlserver" });

            services.AddHealthChecksUI();
        }
    }
}
