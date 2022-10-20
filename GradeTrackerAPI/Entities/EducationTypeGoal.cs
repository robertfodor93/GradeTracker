namespace GradeTrackerAPI.Entities
{
    public class EducationTypeGoal : BaseEntity
    {
        [Column(TypeName="decimal(3,2)")]
        public double? AverageDesiredMark { get; set; }
        public virtual IReadOnlyList<EducationType>? EducationTypes { get; set; }
        [ForeignKey(nameof(UserId))]
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
