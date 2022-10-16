namespace GradeTrackerAPI.Interfaces
{
    public interface IEducationTypesRepository : IGenericRepository<EducationType>
    {
        Task<IReadOnlyList<GetEducationTypeDTO>> GetDetails();
        Task<GetEducationTypeDTO> GetDetail(int id);
    }
}
