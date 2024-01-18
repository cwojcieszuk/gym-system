using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymify.Application.GroupSessions.Commands.DeleteGroupSession;

public record DeleteGroupSessionCommand(Guid GroupSessionUid, Guid UserUid): IRequest<Unit>;
    