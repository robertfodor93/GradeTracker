namespace GradeTrackerAPI.Repositories
{
    public class ModulesRepository : GenericRepository<Module>, IModulesRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ModulesRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
        }
        public async Task<IList<GetModuleDTO>> GetDetails()
        {
            var modules = await _dataContext.Modules.Include(q => q.Marks).Include(q => q.Teacher)
                .ProjectTo<GetModuleDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (modules == null)
            {
                throw new NotFoundException(nameof(GetDetails), modules);
            }

            return modules;
        }

        public async Task<ModuleDTO> GetDetail(int id)
        {
            var module = await _dataContext.Modules.Include(q => q.Marks).Include(q=> q.Teacher)
                .ProjectTo<ModuleDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if(module == null)
            {
                throw new NotFoundException(nameof(GetDetail), id);
            }

            return module;
        }
    }
}
