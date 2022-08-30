namespace GradeTrackerAPI.DataTransferObjects
{
    public class MarkDto
    {
        public double Grade { get; set; }
        public double Weighting { get; set; }
        public DateTime Date { get; set; }
        public int ModuleId { get; set; }
    }
}
