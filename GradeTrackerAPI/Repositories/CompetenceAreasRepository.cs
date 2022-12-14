namespace GradeTrackerAPI.Repositories
{
    public class CompetenceAreasRepository : GenericRepository<CompetenceArea>, ICompetenceAreasRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CompetenceAreasRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

            this._dataContext = dataContext;
            this._mapper = mapper;

        }

        public async Task<IReadOnlyList<GetCompetenceAreaDTO>> GetDetails()
        {
            var competenceAreas = await _dataContext.CompetenceAreas
                .Include(et => et.EducationType)
                .Include(m => m.Modules)
                .ProjectTo<GetCompetenceAreaDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (competenceAreas == null)
            {
                throw new NotFoundException(nameof(GetDetails), competenceAreas);
            }

            return competenceAreas;
        }

        public async Task<GetCompetenceAreaDTO> GetDetail(int id)
        {
            var competenceArea = await _dataContext.CompetenceAreas
                .Include(et => et.EducationType)
                .Include(m => m.Modules)
                .ProjectTo<GetCompetenceAreaDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (competenceArea == null)
            {
                throw new NotFoundException(nameof(GetDetail), id);
            }

            return competenceArea;
        }

        public async Task<IReadOnlyList<GetCompetenceAreaDTO>> GetByEducationType(int educationTypeId)
        {
            var competenceArea = await _dataContext.CompetenceAreas
                .Where(ca => ca.EducationTypeId == educationTypeId)
                .Include(m => m.Modules)
                .ProjectTo<GetCompetenceAreaDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (competenceArea == null)
            {
                throw new NotFoundException(nameof(GetByEducationType), GetByEducationType);
            }

            return competenceArea;
        }
    }
}
