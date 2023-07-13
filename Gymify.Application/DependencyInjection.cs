using System.Reflection;
using Gymify.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Gymify.Application.JWT;

namespace Gymify.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<JwtHandler>();
        return services;
    }
}