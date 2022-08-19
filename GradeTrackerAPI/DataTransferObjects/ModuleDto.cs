namespace GradeTrackerAPI.DataTransferObjects
{
    public class ModuleDto
    {
        [Required]
        public string Name { get; set; }
        public bool ShowOnDashboard { get; set; }
        public double AverageDesiredMark { get; set; }
    }
}
