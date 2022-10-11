namespace GradeTrackerAPI.DataTransferObjects.CompetenceArea
{
    public class GetCompetenceAreaDTO : BaseCompetenceAreaDTO, IBaseDTO
    {
        public int Id { get; set; }
        public List<GetEducationTypeDTO> EducationTypes { get; set; }
        public List<GetModuleDTO> Modules { get; set; }
    }
}
