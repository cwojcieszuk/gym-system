using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using Gymify.Shared.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gymify.Application.Trainings.Queries.GetTraining;

public class GetTrainingsQueryHandler : IRequestHandler<GetTrainingQuery, PagedResponse<TrainingDTO>>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GetTrainingsQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }
    
    public async Task<PagedResponse<TrainingDTO>> Handle(GetTrainingQuery request, CancellationToken cancellationToken)
    {
        List<Guid> trainingUids = await _gymifyDbContext.UserTrainings
            .Where(x => x.UserUid == request.UserUid)
            .Select(u => u.TrainingUid)
            .ToListAsync(cancellationToken);

        List<Training> trainings = await _gymifyDbContext.Training
            .Where(u => trainingUids.Contains(u.TrainingUid))
            .Include(u => u.Template)
            .ToListAsync(cancellationToken);
        
        int totalRecords = trainings.Count;
        int totalPages = totalRecords / request.PageSize + 1;
        
        trainings = trainings.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        List<TrainingDTO> content = trainings.Select(training => new TrainingDTO(
                training.TrainingUid,
                training.TrainingName,
                training.TrainingDate,
                training.IsCyclical,
                training.Template.EstimatedTime,
                training.Template.TemplateName
            )
        ).ToList();
        return new PagedResponse<TrainingDTO>()
        {
            Content = content,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalPages = totalPages,
            TotalRecords = totalRecords
        };
    }
}