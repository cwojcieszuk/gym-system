using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymify.Application.GroupSessions.Queries.GroupSessionOwner;
public class GroupSessionOwnerQueryHandler : IRequestHandler<GroupSessionOwnerQuery, bool>
{
    private readonly IGymifyDbContext _gymifyDbContext;

    public GroupSessionOwnerQueryHandler(IGymifyDbContext gymifyDbContext)
    {
        _gymifyDbContext = gymifyDbContext;
    }

    public async Task<bool> Handle(GroupSessionOwnerQuery request, CancellationToken cancellationToken)
    {
        GroupSession session = await _gymifyDbContext.GroupSessions.FirstAsync(x => x.GroupSessionUid == request.GroupSessionUid);

        return session.CoachUid == request.UserUid;
    }
}
