using System.Text;
using Gymify.Domain.Entities;
using GymifyApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace GymifyApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        
        var jwtSettings = configuration.GetSection("JwtSettings");
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(jwtSettings.GetSection("securityKey").Value))
            };
        });
        
        services.AddScoped<TemplateExistenceCheckFilter>();
        services.AddScoped<TemplateOwnerCheckFilter>();
        services.AddScoped<TrainingExistenceCheckFilter>();
        services.AddScoped<CoachExistenceCheckFilter>();
        services.AddScoped<CoachHourExistenceCheckFilter>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Rights", policy => policy.RequireRole("Admin", "Coach", "User"));
        });
        
        return services;
    }
}