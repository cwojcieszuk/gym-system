using Gymify.Application.Interfaces;
using Gymify.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymify.Application.GroupSessions.Commands.EditGroupSession
{
    public class EditGroupSessionCommandQueryHandler : IRequestHandler<EditGroupSessionCommand, Unit>
    {
        private readonly IGymifyDbContext _gymifyDbContext;

        public EditGroupSessionCommandQueryHandler(IGymifyDbContext gymifyDbContext)
        {
            _gymifyDbContext = gymifyDbContext;
        }

        public async Task<Unit> Handle(EditGroupSessionCommand request, CancellationToken cancellationToken)
        {
            GroupSession session = await _gymifyDbContext.GroupSessions.SingleAsync(x => x.GroupSessionUid == request.GroupSessionUid);

            session.SessionName = request.SessionName;
            session.SessionStartDate = request.SessionStartDate;
            session.SessionEndDate = request.SessionEndDate;
            session.Description = request.Description;
            session.PlaceId = request.PlaceId;
            session.Slots = request.Slots;

            await _gymifyDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
