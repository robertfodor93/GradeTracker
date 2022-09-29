namespace GradeTrackerAPI.DataTransferObjects
{
    public class MarkDto
    {
        public double Grade { get; set; }
        public string Description { get; set; }
        public double Weighting { get; set; }
        public DateTime Date { get; set; }
        public int ModuleId { get; set; }
        public ModuleDto Module { get; set; }
    }
}
