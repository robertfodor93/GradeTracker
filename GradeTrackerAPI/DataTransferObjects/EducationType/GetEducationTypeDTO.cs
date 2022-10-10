namespace GradeTrackerAPI.DataTransferObjects.EducationType
{
    public class GetEducationTypeDTO : BaseEducationTypeDTO, IBaseDTO
    {
        public int Id { get; set; }
        public List<GetCompetenceAreaDTO> CompetenceAreas { get; set; }
    }
}
