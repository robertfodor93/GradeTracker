namespace GradeTrackerAPI.Entities
{
    public class CompetenceArea : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Weighting { get; set; }
        public virtual IReadOnlyList<Module>? Modules { get; set; }
        public virtual IReadOnlyList<CompetenceAreaEducationType> EducationTypes { get; set; }
    }
}
