using Mayhem.Configuration.Interfaces;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Mayhem.Setup
{
    public static class SetupExtensions
    {
        public static void AddApplicationInsightWithDefaultProcessor(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        {
            ApplicationInsightsServiceOptions aiOptions = new()
            {
                InstrumentationKey = mayhemConfiguration.MayhemConfiguration.ConnectionStringsConfigruation.AppInsightInstrumentationKeyAPP,
            };

            services.AddApplicationInsightsTelemetry(aiOptions);
            services.AddApplicationInsightsTelemetryProcessor<DefaultTelemetryProcessor>();
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IMayhemConfigurationService mayhemConfiguration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = mayhemConfiguration.MayhemConfiguration.ServiceSecretsConfigruation.JwtIssuer,
                    ValidAudience = mayhemConfiguration.MayhemConfiguration.ServiceSecretsConfigruation.JwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mayhemConfiguration.MayhemConfiguration.ServiceSecretsConfigruation.JwtKey)),
                    ClockSkew = TimeSpan.Zero,
                };

                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
