namespace GradeTrackerAPI.DataTransferObjects.Module
{
    public class BaseModuleDTO
    {
        [Required]
        public string Name { get; set; }
        public double AverageDesiredMark { get; set; }
    }
}
