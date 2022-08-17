namespace GradeTrackerAPI.Entities
{
    public class EducationType : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Calculation { get; set; }
        public EducationTypeGoal? EducationTypeGoal { get; set; }
        public IEnumerable<CompetenceArea>? CompetenceAreas { get; set; }
    }
}
