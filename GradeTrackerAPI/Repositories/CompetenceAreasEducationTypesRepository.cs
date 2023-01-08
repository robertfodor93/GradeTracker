namespace GradeTrackerAPI.Repositories
{
    public class CompetenceAreasEducationTypesRepository
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CompetenceAreasEducationTypesRepository(DataContext dataContext, IMapper mapper)
        {

            this._dataContext = dataContext;
            this._mapper = mapper;

        }

    }
}
