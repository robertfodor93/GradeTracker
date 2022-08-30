namespace GradeTrackerAPI.DataTransferObjects
{
    public class CompetenceAreaDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Module>? Modules { get; set; }
    }
}
