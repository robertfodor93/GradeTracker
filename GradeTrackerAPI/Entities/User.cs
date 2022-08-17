namespace GradeTrackerAPI.Entities
{
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string? Username { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public ICollection<EducationTypeGoal>? EducationTypeGoals { get; set; }
        public ICollection<Module>? Modules { get; set; }
    }
}
