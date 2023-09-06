using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Templates.Commands.DeleteTemplate;

public class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand, Unit>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public DeleteTemplateCommandHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<Unit> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = await _gymifyDbContext.Templates
            .Include(x => x.TemplateExercises)
            .SingleAsync(x => x.TemplateUid == request.TemplateUid, cancellationToken);
        
        template.TemplateExercises.Clear();

        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        _gymifyDbContext.Templates.Remove(template);
        await _gymifyDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}