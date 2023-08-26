namespace Gymify.Domain.Entities;

public class ClientGroupSession
{
    public Guid ClientGroupSessionUid { get; set; }
    
    public Guid GroupSessionUid { get; set; }
    
    public Guid ClientUid { get; set; }

    public virtual GroupSession GroupSession { get; set; }

    public virtual Client Client { get; set; } 
}