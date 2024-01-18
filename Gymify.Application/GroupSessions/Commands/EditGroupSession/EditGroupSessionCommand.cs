using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymify.Application.GroupSessions.Commands.EditGroupSession;
public record EditGroupSessionCommand(Guid GroupSessionUid, string SessionName, int Slots, DateTime SessionStartDate, DateTime SessionEndDate, string Description, int PlaceId, Guid CoachUid) : IRequest<Unit>;


