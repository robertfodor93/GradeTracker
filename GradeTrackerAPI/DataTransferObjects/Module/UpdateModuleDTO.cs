namespace GradeTrackerAPI.DataTransferObjects.Module
{
    public class UpdateModuleDTO : IBaseDTO
    {
        public int Id { get; set; }
        public double? AverageDesiredMark { get; set; }
    }
}
