namespace GradeTrackerAPI.DataTransferObjects
{
    public class TeacherDto
    {
        public virtual IList<ModuleDto> Modules { get; set; }

    }

    public class CreateTeacherDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
