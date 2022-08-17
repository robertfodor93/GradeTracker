namespace GradeTrackerAPI.Entities
{
    public class Teacher : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public ICollection<Module>? Modules { get; set; }
    }
}
