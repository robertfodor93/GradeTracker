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

        public async Task<List<GetEducationTypeDTO>> GetDetails()
        {
            var educationTypes = await _dataContext.EducationTypes
                .ProjectTo<GetEducationTypeDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (educationTypes == null)
            {
                throw new NotFoundException(nameof(GetDetails), educationTypes);
            }

            return educationTypes;
        }
    }
}
