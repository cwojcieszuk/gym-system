namespace Gymify.Domain.Entities;

public class CoachType
{
    public Guid CoachTypeUid { get; set; }
    
    public Guid CoachUid { get; set; }
    
    public Guid CoachCategoryUid { get; set; }
    
    public virtual Coach Coach { get; set; }
    
    public virtual CoachCategory CoachCategory { get; set; }
}