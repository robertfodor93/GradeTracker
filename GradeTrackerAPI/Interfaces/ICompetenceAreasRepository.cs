namespace GradeTrackerAPI.Interfaces
{
    public interface ICompetenceAreasRepository : IGenericRepository<CompetenceArea>
    {
        Task<IReadOnlyList<GetCompetenceAreaDTO>> GetDetails();
        Task<GetCompetenceAreaDTO> GetDetail(int id);

        Task<IReadOnlyList<GetCompetenceAreaDTO>> GetByEducationType(int educationTypeId);
    }
}
