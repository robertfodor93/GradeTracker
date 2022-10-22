namespace GradeTrackerAPI.Interfaces
{
    public interface IEducationTypeGoalsRepository : IGenericRepository<EducationTypeGoal>
    {
        Task<IReadOnlyList<GetEducationTypeGoalDTO>> GetDetails();
        Task<GetEducationTypeGoalDTO> GetDetail(int id);
    }
}
