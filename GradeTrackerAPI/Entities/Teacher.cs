namespace GradeTrackerAPI.Entities
{
    public class Teacher : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public virtual ICollection<Module>? Modules { get; set; }
    }
}
