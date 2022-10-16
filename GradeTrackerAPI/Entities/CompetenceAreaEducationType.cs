namespace GradeTrackerAPI.Entities
{
    public class CompetenceAreaEducationType
    {
        public int CompetenceAreaId { get; set; }
        public virtual CompetenceArea CompetenceArea { get; set; }
        public int EducationTypeId { get; set; }
        public virtual EducationType EducationType { get; set; }

    }
}
