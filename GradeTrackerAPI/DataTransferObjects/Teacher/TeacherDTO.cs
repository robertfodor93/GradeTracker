namespace GradeTrackerAPI.DataTransferObjects.Teacher
{
    public class TeacherDTO : BaseTeacherDTO, IBaseDTO
    {
        public int Id { get; set; }
        public List<BaseModuleDTO> Modules { get; set; }
    }
}
