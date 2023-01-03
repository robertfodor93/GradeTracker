namespace GradeTrackerAPI.DataTransferObjects.Teacher
{
    public class UpdateTeacherDTO : BaseTeacherDTO, IBaseDTO
    {
        public int Id { get; set; }
    }
}
