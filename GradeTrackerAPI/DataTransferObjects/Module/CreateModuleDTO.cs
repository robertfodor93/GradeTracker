namespace GradeTrackerAPI.DataTransferObjects.Module
{
    public class CreateModuleDTO : BaseModuleDTO
    {
        public BaseTeacherDTO? Teacher { get; set; }
        public int CompetenceAreaId { get; set; }
        public CompetenceAreaDTO? CompetenceArea { get; set; }
        public int UserId { get; set; }
        public BaseUserDTO? User { get; set; }
    }
}
