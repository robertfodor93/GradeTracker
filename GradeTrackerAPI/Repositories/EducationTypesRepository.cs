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
                .Include(et => et.CompetenceAreas)
                .ThenInclude(ce => ce.CompetenceArea)
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
            var competenceArea = await _dataContext.EducationTypes
                .Include(ca => ca.CompetenceAreas)
                .ThenInclude(ce => ce.CompetenceArea)
                .ProjectTo<GetEducationTypeDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (competenceArea == null)
            {
                throw new NotFoundException(nameof(GetDetail), id);
            }

            return competenceArea;
        }
    }
}
