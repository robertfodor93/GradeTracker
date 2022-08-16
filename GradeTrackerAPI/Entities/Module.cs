namespace GradeTrackerAPI.Entities
{
    public class Module : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool ShowOnDashboard { get; set; } = false;
        public double AverageDesiredMark { get; set; }
        public CompetenceArea CompetenceArea { get; set; } = new CompetenceArea();
        public Teacher Teacher { get; set; } = new Teacher();
        public ICollection<Mark> Marks { get; set; } = new List<Mark>();
        public User User { get; set; } = new User();
    }
}
