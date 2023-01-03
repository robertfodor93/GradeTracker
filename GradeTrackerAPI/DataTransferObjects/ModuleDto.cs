namespace GradeTrackerAPI.DataTransferObjects
{
    public class ModuleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShowOnDashboard { get; set; }
        public double AverageDesiredMark { get; set; }
        public UserDto User { get; set; }
        public TeacherDto Teacher { get; set; }
        public CompetenceAreaDto CompetenceArea { get; set; }
        public ICollection<MarkDto> Marks { get; set; }
    }

    public class CreateModuleDto : UpdateModuleDto
    {
        public int? UserId { get; set; }
    }

    public class UpdateModuleDto
    {
        public string Name { get; set; }
        public bool ShowOnDashboard { get; set; }
        public double AverageDesiredMark { get; set; }
        public TeacherDto? Teacher { get; set; }
        public ICollection<MarkDto>? Marks { get; set; }
        public int? CompetenceAreaId { get; set; }
    }
}
