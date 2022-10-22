namespace GradeTrackerAPI.Repositories
{
    public class EducationTypesRepository : GenericRepository<EducationType>, IEducationTypesRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EducationTypesRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyList<GetEducationTypeDTO>> GetDetails()
        {
            var educationTypes = await _dataContext.EducationTypes
                .Include(ca => ca.CompetenceAreas)
                .ThenInclude(ca => ca.Modules)
                .ProjectTo<GetEducationTypeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (educationTypes == null)
            {
                throw new NotFoundException(nameof(GetDetails), educationTypes);
            }

            return educationTypes;
        }

        public async Task<GetEducationTypeDTO> GetDetail(int id)
        {
            var educationType = await _dataContext.EducationTypes
                .Include(ca => ca.CompetenceAreas)
                .ThenInclude(ca => ca.Modules)
                .ProjectTo<GetEducationTypeDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (educationType == null)
            {
                throw new NotFoundException(nameof(GetDetail), id);
            }

            return educationType;
        }
    }
}
