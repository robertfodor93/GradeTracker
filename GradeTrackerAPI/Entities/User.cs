namespace GradeTrackerAPI.Entities
{
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public byte[] PasswordHash { get; set; } = new byte[32];
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public string Role { get; set; } = string.Empty;
        public virtual IList <EducationTypeGoal>? EducationTypeGoals { get; set; }
        public virtual IList<Module>? Modules { get; set; }
    }
}
