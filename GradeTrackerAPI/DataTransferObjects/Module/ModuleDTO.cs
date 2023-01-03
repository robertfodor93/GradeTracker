namespace GradeTrackerAPI.DataTransferObjects.Module
{
    public class ModuleDTO : BaseModuleDTO, IBaseDTO
    {
        public int Id { get; set; }
        public List<BaseMarkDTO> Marks { get; set; }
        public BaseTeacherDTO Teacher { get; set; }
    }
}
