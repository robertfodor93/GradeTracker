namespace GradeTrackerAPI.Entities
{
    public class CompetenceArea : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Weighting { get; set; }
        public virtual IList<Module>? Modules { get; set; }
        [ForeignKey(nameof(EducationTypeId))]
        public int? EducationTypeId { get; set; }
        public EducationType? EducationType { get; set; }
    }
}
