namespace Gymify.Application.Coaches.Queries.GetCoaches;

public record CoachDTO(Guid CoachUid, string CoachName, string Gender, byte[]? Avatar, IEnumerable<string> Categories, string Description, bool IsFavorite);