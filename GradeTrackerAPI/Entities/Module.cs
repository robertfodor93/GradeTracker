namespace GradeTrackerAPI.Entities
{
    public class Module : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public bool? ShowOnDashboard { get; set; } = false;
        public double? AverageDesiredMark { get; set; }
        public int? CompetenceAreaId { get; set; }
        public CompetenceArea? CompetenceArea { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Mark>? Marks { get; set; }
    }
}
