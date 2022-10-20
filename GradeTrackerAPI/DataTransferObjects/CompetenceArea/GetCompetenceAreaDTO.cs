namespace GradeTrackerAPI.DataTransferObjects.CompetenceArea
{
    public class GetCompetenceAreaDTO : BaseCompetenceAreaDTO, IBaseDTO
    {
        public int Id { get; set; }
        public virtual List<GetModuleDTO> Modules { get; set; }
        [JsonIgnore]
        public virtual GetEducationTypeDTO EducationType { get; set; }
    }
}
