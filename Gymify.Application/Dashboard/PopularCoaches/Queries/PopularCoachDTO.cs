using System.Collections;

namespace Gymify.Application.Dashboard.Queries;

public record PopularCoachDTO(Guid CoachUid, string CoachName, byte[] Avatar, IEnumerable<string> Categories, bool IsFavourite);