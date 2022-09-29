namespace GradeTrackerAPI.Entities
{
    public class EducationTypeGoal : BaseEntity
    {
        [Column(TypeName="decimal(3,2)")]
        public double? AverageDesiredMark { get; set; }
        public virtual IList<EducationType>? EducationTypes { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
