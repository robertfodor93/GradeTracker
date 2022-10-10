namespace GradeTrackerAPI.DataTransferObjects.Module
{
    public class CreateModuleDTO : BaseModuleDTO
    {
        public BaseTeacherDTO? Teacher { get; set; }
    }
}
