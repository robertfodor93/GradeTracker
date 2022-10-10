namespace GradeTrackerAPI.Repositories
{
    public class TeachersRepositorty : GenericRepository<Teacher>, ITeachersRepository
    {
        public TeachersRepositorty(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
    }
}
