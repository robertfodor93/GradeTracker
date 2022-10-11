namespace GradeTrackerAPI.Entities
{
    public class Module : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public bool? ShowOnDashboard { get; set; } = false;
        public double? AverageDesiredMark { get; set; }
        public List<Mark>? Marks { get; set; }
        [ForeignKey(nameof(CompetenceAreaId))]
        public int? CompetenceAreaId { get; set; }
        public CompetenceArea? CompetenceArea { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public User? User { get; set; }
    }
}
