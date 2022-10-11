namespace GradeTrackerAPI.Entities
{
    public class CompetenceAreaEducationType
    {
        public int CompetenceAreaId { get; set; }
        public CompetenceArea CompetenceArea { get; set; }
        public int EducationTypeId { get; set; }
        public EducationType EducationType { get; set; }

    }
}
