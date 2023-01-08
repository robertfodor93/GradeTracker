namespace GradeTrackerAPI.Interfaces
{
    public interface IModulesRepository : IGenericRepository<Module>
    {
        Task<IList<GetModuleDTO>> GetDetails();
        Task<ModuleDTO> GetDetail(int id);
    }
}
