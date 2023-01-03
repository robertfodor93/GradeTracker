namespace GradeTrackerAPI.Entities
{
    public class EducationType : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Calculation { get; set; }
        public virtual IList<CompetenceArea> CompetenceAreas { get; set; }
        public virtual IList<EducationTypeGoal> EducationTypeGoals { get; set; }
    }
}
