using System.Net;
using System.Net.Mime;
using FluentValidation;
using Newtonsoft.Json;

namespace GymifyApi.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IWebHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationException(context, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleValidationException(HttpContext context, ValidationException validationException)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest; 

        var result = new
        {
            Status = context.Response.StatusCode,
            Errors = validationException.Errors.Select(a => a.ErrorMessage)
        };

        string json = JsonConvert.SerializeObject(result);
        return context.Response.WriteAsync(json);
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = new
        {
            Status = context.Response.StatusCode,
            Errors = _environment.IsDevelopment() ? new[] { exception.Message } : null
        };

        string json = JsonConvert.SerializeObject(result);
        return context.Response.WriteAsync(json);
    }
}