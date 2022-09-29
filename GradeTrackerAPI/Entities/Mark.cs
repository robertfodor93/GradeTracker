namespace GradeTrackerAPI.Entities
{
    public class Mark : BaseEntity
    {
        public double? Grade { get; set; }
        public string? Description { get; set; } = string.Empty;
        public double? Weighting { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        [ForeignKey(nameof(ModuleId))]
        public Module Module { get; set; }
        public int ModuleId { get; set; }
    }
}
