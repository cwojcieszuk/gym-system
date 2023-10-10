using MediatR;

namespace Gymify.Application.Profile.Commands.UpdateCoachData;

public record UpdateCoachDataCommand(Guid UserUid, string? Description, List<int> CategoryId): IRequest<Unit>;