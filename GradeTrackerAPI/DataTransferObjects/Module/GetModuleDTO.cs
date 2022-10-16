namespace GradeTrackerAPI.DataTransferObjects.Module
{
    public class GetModuleDTO : BaseModuleDTO, IBaseDTO
    {
        public int Id { get; set; }
        public GetTeacherDTO Teacher { get; set; }
        public GetCompetenceAreaDTO CompetenceArea { get; set; }
        public List<GetMarkDTO> Marks { get; set; }
        public GetUserDTO User { get; set; }
    }
}
