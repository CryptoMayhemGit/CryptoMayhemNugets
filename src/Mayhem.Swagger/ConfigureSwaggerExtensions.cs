using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Mayhem.Swagger
{
    public static class ConfigureSwaggerExtensions
    {
        public static void ConfigureSwaggerWithExamples<T>(this IServiceCollection services, string apiTitle, IEnumerable<string> commentsFileNames = null, bool enableAuth = false)
            where T : class, new()
        {
            const string apiVersion = "v1";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(apiVersion, new OpenApiInfo { Title = apiTitle, Version = apiVersion });
                c.ExampleFilters();

                if (commentsFileNames != null)
                {
                    foreach (string fileName in commentsFileNames)
                    {
                        string xmlPath = Path.Combine(AppContext.BaseDirectory, fileName);
                        c.IncludeXmlComments(xmlPath);
                    }
                }

                if (enableAuth)
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
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
                            Array.Empty<string>()
                        }
                    });
                }

            });

            services.AddSwaggerExamplesFromAssemblyOf(typeof(T));
        }

        public static void UseOwnSwagger(this IApplicationBuilder app, string apiTitle)
        {
            const string apiVersion = "v1";
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", apiTitle);
                c.IndexStream = () => MethodBase.GetCurrentMethod().DeclaringType.Assembly.GetManifestResourceStream($"{typeof(ConfigureSwaggerExtensions).Namespace}.SwaggerIndex.html");
            });
        }
    }
}
