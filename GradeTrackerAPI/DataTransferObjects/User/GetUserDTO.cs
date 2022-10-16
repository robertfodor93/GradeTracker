namespace GradeTrackerAPI.DataTransferObjects.User
{
    public class GetUserDTO : BaseUserDTO, IBaseDTO
    {
        public int Id { get; set; }
    }
}
