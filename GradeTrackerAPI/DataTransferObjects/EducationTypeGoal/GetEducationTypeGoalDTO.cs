namespace GradeTrackerAPI.DataTransferObjects.EducationTypeGoal
{
    public class GetEducationTypeGoalDTO : BaseEducationTypeGoalDTO, IBaseDTO
    {
        public int Id { get; set; }
        public int EducationTypeId { get; set; }
        public GetEducationTypeDTO EducationType { get; set; }
        public string UserId { get; set; }
        public GetUserDTO User { get; set; }
    }
}
