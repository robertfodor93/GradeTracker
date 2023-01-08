namespace GradeTrackerAPI.DataTransferObjects.Mark
{
    public class MarkDTO : BaseMarkDTO, IBaseDTO
    {
        public int Id { get; set; }
        public BaseModuleDTO Module { get; set; }
    }
}
