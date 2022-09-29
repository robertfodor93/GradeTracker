namespace GradeTrackerAPI.Entities
{
    public class Teacher : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public virtual IList<Module>? Modules { get; set; }
    }
}
