using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gymify.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<GymifyDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("gymify")));
        services.AddIdentity<AspNetUser, IdentityRole>().AddEntityFrameworkStores<GymifyDbContext>();
        services.AddScoped<IGymifyDbContext, GymifyDbContext>();
        
        return services;
    }
}