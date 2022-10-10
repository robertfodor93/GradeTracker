namespace GradeTrackerAPI.DataTransferObjects.CompetenceArea
{
    public class GetCompetenceAreaDTO : BaseCompetenceAreaDTO, IBaseDTO
    {
        public int Id { get; set; }
        public GetEducationTypeDTO EducationType { get; set; }
        public List<GetModuleDTO> Modules { get; set; }
    }
}
