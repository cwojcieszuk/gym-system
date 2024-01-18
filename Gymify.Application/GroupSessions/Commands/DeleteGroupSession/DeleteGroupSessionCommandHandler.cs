using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymify.Application.GroupSessions.Commands.DeleteGroupSession
{
    public class DeleteGroupSessionCommandHandler : IRequestHandler<DeleteGroupSessionCommand, Unit>
    {
        private readonly IGymifyDbContext _gymifyDbContext;

        public DeleteGroupSessionCommandHandler(IGymifyDbContext gymifyDbContext)
        {
            _gymifyDbContext = gymifyDbContext;
        }

        public async Task<Unit> Handle(DeleteGroupSessionCommand request, CancellationToken cancellationToken)
        {
            GroupSession session = await _gymifyDbContext.GroupSessions.SingleAsync(x => x.GroupSessionUid == request.GroupSessionUid);

            _gymifyDbContext.GroupSessions.Remove(session);
            await _gymifyDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
