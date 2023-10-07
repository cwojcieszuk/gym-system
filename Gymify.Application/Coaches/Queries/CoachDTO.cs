namespace Gymify.Application.Coaches.Queries;

public record CoachDTO(Guid CoachUid, string CoachName, string Gender, byte[]? Avatar, IEnumerable<string> Categories, string Description, bool IsFavorite);