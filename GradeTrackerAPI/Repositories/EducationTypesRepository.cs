namespace GradeTrackerAPI.Repositories
{
    public class EducationTypesRepository : GenericRepository<EducationType>, IEducationTypesRepository
    {
        public EducationTypesRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
    }
}
