namespace GradeTrackerAPI.Entities
{
    public class Mark : BaseEntity
    {
        public double Grade { get; set; }
        public double Weighting { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Module Module { get; set; } = new Module();
    }
}
