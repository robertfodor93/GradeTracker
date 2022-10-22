namespace GradeTrackerAPI.DataTransferObjects.EducationTypeGoal
{
    public class CreateEducationTypeGoalDTO : BaseEducationTypeGoalDTO
    {
        public int EducationTypeId { get; set; }
        public int UserId { get; set; }
    }
}
