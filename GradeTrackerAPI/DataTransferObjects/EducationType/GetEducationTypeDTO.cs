namespace GradeTrackerAPI.DataTransferObjects.EducationType
{
    public class GetEducationTypeDTO : BaseEducationTypeDTO, IBaseDTO
    {
        public int Id { get; set; }
        public IList<GetCompetenceAreaDTO> CompetenceAreas { get; set; }
    }
}
