namespace GradeTrackerAPI.Entities
{
    public class CompetenceArea : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Weighting { get; set; }
        public List<Module>? Modules { get; set; }
        public IList<EducationType>? EducationTypes { get; set; }
    }
}
