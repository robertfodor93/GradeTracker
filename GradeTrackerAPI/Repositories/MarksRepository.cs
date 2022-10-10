namespace GradeTrackerAPI.Repositories
{
    public class MarksRepository : GenericRepository<Mark>, IMarksRepository
    {
        public MarksRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
    }
}
