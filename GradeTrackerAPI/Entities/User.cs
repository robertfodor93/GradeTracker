namespace GradeTrackerAPI.Entities
{
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public ICollection<EducationTypeGoal>? EducationTypeGoals { get; set; }
        public ICollection<Module>? Modules { get; set; }
    }
}
