namespace GradeTrackerAPI.DataTransferObjects
{
    public class CompetenceAreaDto
    {
        public string Name { get; set; } = string.Empty;
        public IList<ModuleDto> Modules { get; set; }
    }
}
