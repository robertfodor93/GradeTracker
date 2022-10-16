namespace GradeTrackerAPI.Entities
{
    public class Module : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public bool? ShowOnDashboard { get; set; } = false;
        public double? AverageDesiredMark { get; set; }
        public virtual IList<Mark>? Marks { get; set; }
        [ForeignKey(nameof(CompetenceAreaId))]
        public int? CompetenceAreaId { get; set; }
        public virtual CompetenceArea? CompetenceArea { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual User? User { get; set; }
    }
}
