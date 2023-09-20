namespace Gymify.Domain.Entities;

public class Template
{
    public Guid TemplateUid { get; set; }

    public string TemplateName { get; set; } = null!;

    public int DifficultyLevelId { get; set; }

    public decimal EstimatedTime { get; set; }
    
    public Guid UserUid { get; set; }

    public bool IsShared { get; set; }
    
    public virtual AspNetUser User { get; set; }

    public virtual DifficultyLevel DifficultyLevel { get; set; } = null!;

    public virtual ICollection<TemplateExercise> TemplateExercises { get; set; } = new List<TemplateExercise>();

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
