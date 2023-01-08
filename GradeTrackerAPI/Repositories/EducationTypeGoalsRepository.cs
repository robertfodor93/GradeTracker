namespace GradeTrackerAPI.Repositories
{
    public class EducationTypeGoalsRepository : GenericRepository<EducationTypeGoal>, IEducationTypeGoalsRepository
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public EducationTypeGoalsRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
        }

        public async Task<IReadOnlyList<GetEducationTypeGoalDTO>> GetDetails()
        {
            var educationTypeGoals = await _dataContext.EducationTypeGoals
                .ProjectTo<GetEducationTypeGoalDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (educationTypeGoals == null)
            {
                throw new NotFoundException(nameof(GetDetails), educationTypeGoals);
            }

            return educationTypeGoals;
        }

        public async Task<GetEducationTypeGoalDTO> GetDetail(int id)
        {
            var educationTypeGoal = await _dataContext.EducationTypeGoals
                .ProjectTo<GetEducationTypeGoalDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (educationTypeGoal == null)
            {
                throw new NotFoundException(nameof(GetDetail), id);
            }

            return educationTypeGoal;
        }
    }
}
