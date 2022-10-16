namespace GradeTrackerAPI.DataTransferObjects.CompetenceArea
{
    public class GetCompetenceAreaDTO : BaseCompetenceAreaDTO, IBaseDTO
    {
        public int Id { get; set; }
        [JsonIgnore]
        public virtual IReadOnlyList<GetEducationTypeDTO> EducationTypes { get; set; }
        public virtual IReadOnlyList<GetModuleDTO> Modules { get; set; }
    }
}
