namespace GradeTrackerAPI.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<EducationTypeGoal> EducationTypeGoals { get; }
        IGenericRepository<EducationType> EducationTypes { get; }
        IGenericRepository<CompetenceArea> CompetenceAreas { get; }
        IGenericRepository<Module> Modules { get; }
        IGenericRepository<Teacher> Teachers { get; }
        IGenericRepository<Mark> Marks { get; }
        Task Save();
    }
}
