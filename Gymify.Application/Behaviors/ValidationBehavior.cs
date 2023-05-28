using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Gymify.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,  CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        IValidationContext context = new ValidationContext<TRequest>(request);
        IEnumerable<Task<ValidationResult>> validators = _validators
            .Select(x => x.ValidateAsync(context, cancellationToken));
        
        ValidationResult[] validationResults = await Task.WhenAll(validators);
        IEnumerable<ValidationFailure> validationFailures = validationResults
            .SelectMany(x => x.Errors)
            .Where(x => x != null);

        if (validationFailures.Any())
        {
            throw new ValidationException(validationFailures);
        }

        return await next();
    }
    
}