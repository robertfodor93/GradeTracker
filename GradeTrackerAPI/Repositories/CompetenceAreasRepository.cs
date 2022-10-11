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

        public async Task<IList<GetCompetenceAreaDTO>> GetDetails()
        {
            var competenceAreas = await _dataContext.CompetenceAreas
                .Include(q => q.EducationTypes)
                .ProjectTo<GetCompetenceAreaDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (competenceAreas == null)
            {
                throw new NotFoundException(nameof(GetDetails), competenceAreas);
            }

            return competenceAreas;
        }
    }
}
