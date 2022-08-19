namespace GradeTrackerAPI.DataTransferObjects
{
    public class ModuleDto
    {
        [Required]
        public string Name { get; set; }
        public bool ShowOnDashboard { get; set; }
        public double AverageDesiredMark { get; set; }
    }

    public class CreateModuleDto : ModuleDto
    {
        public CompetenceAreaDto CompetenceArea { get; set; }
        public TeacherDto Teacher { get; set; }
    }

    public class UpdateModuleDto : CreateModuleDto
    {

    }
}
