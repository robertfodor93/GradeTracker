namespace GradeTrackerAPI.DataTransferObjects.Mark
{
    public class BaseMarkDTO
    {
        [Required]
        public double Grade { get; set; }
        public string Description { get; set; }
        public double Weighting { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int ModuleId { get; set; }
    }
}
