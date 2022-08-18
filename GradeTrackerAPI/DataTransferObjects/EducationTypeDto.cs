namespace GradeTrackerAPI.DataTransferObjects
{
    public class EducationTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public IList<CompetenceAreaDto> CompetenceAreas { get; set; }
    }
}
