namespace GradeTrackerAPI.Repositories
{
    public class TeacherRepositorty : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepositorty(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
    }
}
