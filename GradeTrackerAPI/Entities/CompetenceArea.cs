namespace GradeTrackerAPI.Entities
{
    public class CompetenceArea : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public double Weighting { get; set; }
        public EducationType EducationType { get; set; } = new EducationType();
        public ICollection<Module>? Modules { get; set; }
    }
}
