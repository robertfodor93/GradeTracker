namespace GradeTrackerAPI.Entities
{
    public class EducationType : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Calculation { get; set; }
        public virtual IReadOnlyList<CompetenceAreaEducationType> CompetenceAreas { get; set; }
        [ForeignKey(nameof(EducationTypeGoalId))]
        public int? EducationTypeGoalId { get; set; }
        public virtual EducationTypeGoal? EducationTypeGoal { get; set; }
    }
}
