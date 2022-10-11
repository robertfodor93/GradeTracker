namespace GradeTrackerAPI.DataTransferObjects.EducationType
{
    public class GetEducationTypeDTO : BaseEducationTypeDTO, IBaseDTO
    {
        public int Id { get; set; }
        [JsonIgnore]
        public List<GetCompetenceAreaDTO> CompetenceAreas { get; set; }
    }
}
