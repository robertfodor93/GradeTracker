namespace GradeTrackerAPI.Repositories
{
    public class CompetenceAreasRepository : GenericRepository<CompetenceArea>, ICompetenceAreasRepository
    {
        public CompetenceAreasRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
    }
}
