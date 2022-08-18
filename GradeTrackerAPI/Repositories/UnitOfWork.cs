namespace GradeTrackerAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        private IGenericRepository<User> _users;
        private IGenericRepository<EducationTypeGoal> _educationTypeGoals;
        private IGenericRepository<EducationType> _educationType;
        private IGenericRepository<CompetenceArea> _competenceAreas;
        private IGenericRepository<Module> _modules;
        private IGenericRepository<Teacher> _teachers;
        private IGenericRepository<Mark> _marks;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_dataContext);

        public IGenericRepository<EducationTypeGoal> EducationTypeGoals => _educationTypeGoals ??= new GenericRepository<EducationTypeGoal>(_dataContext);

        public IGenericRepository<EducationType> EducationTypes => _educationType ??= new GenericRepository<EducationType>(_dataContext);

        public IGenericRepository<CompetenceArea> CompetenceAreas => _competenceAreas ??= new GenericRepository<CompetenceArea>(_dataContext);

        public IGenericRepository<Module> Modules => _modules ??= new GenericRepository<Module>(_dataContext);

        public IGenericRepository<Teacher> Teachers => _teachers ??= new GenericRepository<Teacher>(_dataContext);

        public IGenericRepository<Mark> Marks => _marks ??= new GenericRepository<Mark>(_dataContext);

        public void Dispose()
        {
            _dataContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
