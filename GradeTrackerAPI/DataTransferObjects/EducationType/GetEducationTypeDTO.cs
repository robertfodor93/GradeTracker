namespace GradeTrackerAPI.DataTransferObjects.EducationType
{
    public class GetEducationTypeDTO : BaseEducationTypeDTO, IBaseDTO
    {
        public int Id { get; set; }
        public virtual IReadOnlyList<GetCompetenceAreaDTO> CompetenceAreas { get; set; }
    }
}
