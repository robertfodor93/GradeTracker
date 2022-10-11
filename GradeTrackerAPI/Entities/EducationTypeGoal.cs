namespace GradeTrackerAPI.Entities
{
    public class EducationTypeGoal : BaseEntity
    {
        [Column(TypeName="decimal(3,2)")]
        public double? AverageDesiredMark { get; set; }
        public List<EducationType>? EducationTypes { get; set; }
        public User? User { get; set; }
    }
}
