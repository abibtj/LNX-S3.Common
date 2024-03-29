using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
//using Swashbuckle.Swagger;
using System.Collections.Generic;

namespace S3.Common.Swagger
{
    public static class Extensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        {
            SwaggerOptions options;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                services.Configure<SwaggerOptions>(configuration.GetSection("swagger"));
                options = configuration.GetOptions<SwaggerOptions>("swagger");
            }

            if (!options.Enabled)
            {
                return services;
            }

            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(options.Name, new OpenApiInfo { Title = options.Title, Version = options.Version });

                if (options.IncludeSecurity)
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
                }
            });

            //return services;
        }

        //public static IServiceCollection AddSwaggerDocs(this IServiceCollection services)
        //{
        //    SwaggerOptions options;
        //    using (var serviceProvider = services.BuildServiceProvider())
        //    {
        //        var configuration = serviceProvider.GetService<IConfiguration>();
        //        services.Configure<SwaggerOptions>(configuration.GetSection("swagger"));
        //        options = configuration.GetOptions<SwaggerOptions>("swagger");
        //    }

        //    if (!options.Enabled)
        //    {
        //        return services;
        //    }

        //    return services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc(options.Name, new Info { title = options.Title, version = options.Version });
        //        if (options.IncludeSecurity)
        //        {
        //            c.AddSecurityDefinition("Bearer", new ApiKeyScheme
        //            {
        //                Description =
        //                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        //                Name = "Authorization",
        //                In = "header",
        //                Type = "apiKey"
        //            });

        //            c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
        //            {
        //                { "Bearer", new string[] {} }
        //            });
        //        }
        //    });
        //}

        public static IApplicationBuilder UseSwaggerDocs(this IApplicationBuilder builder)
        {
            var options = builder.ApplicationServices.GetService<IConfiguration>()
                .GetOptions<SwaggerOptions>("swagger");
            if (!options.Enabled)
            {
                return builder;
            }

            var routePrefix = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "swagger" : options.RoutePrefix;

            builder.UseStaticFiles()
                .UseSwagger(c => c.RouteTemplate = routePrefix + "/{documentName}/swagger.json");

            return options.ReDocEnabled
                ? builder.UseReDoc(c =>
                {
                    c.RoutePrefix = routePrefix;
                    c.SpecUrl = $"{options.Name}/swagger.json";
                })
                : builder.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/{routePrefix}/{options.Name}/swagger.json", options.Title);
                    c.RoutePrefix = routePrefix;
                    // The Swagger json definition will be available at "{baseUrl}/{routPrefix}/{options.Name}/swagger.json" e.g "http://localhost:4001/docs/v1/swagger.json"
                    // The Swagger UI will be available at "{baseUrl}/{routPrefix}/index.html" e.g "http://localhost:4001/docs/index.html"
                });
        }
    }
}