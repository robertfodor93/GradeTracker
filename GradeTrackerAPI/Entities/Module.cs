namespace GradeTrackerAPI.Entities
{
    public class Module : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public bool? ShowOnDashboard { get; set; } = false;
        public double? AverageDesiredMark { get; set; }
        public virtual IList<Mark>? Marks { get; set; }
        [ForeignKey(nameof(CompetenceAreaId))]
        public CompetenceArea? CompetenceArea { get; set; }
        public int? CompetenceAreaId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
