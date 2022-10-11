namespace GradeTrackerAPI.Entities
{
    public class Teacher : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public List<Module>? Modules { get; set; }
    }
}
