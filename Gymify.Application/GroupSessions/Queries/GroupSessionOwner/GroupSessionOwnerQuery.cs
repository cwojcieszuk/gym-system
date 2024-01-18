using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymify.Application.GroupSessions.Queries.GroupSessionOwner;

public record GroupSessionOwnerQuery(Guid GroupSessionUid, Guid UserUid): IRequest<bool>;
