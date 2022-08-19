namespace GradeTrackerAPI.Entities
{
    public class CompetenceArea : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Weighting { get; set; }
        public int? EducationTypeId { get; set; }
        public EducationType? EducationType { get; set; }
        public ICollection<Module>? Modules { get; set; }
    }
}
