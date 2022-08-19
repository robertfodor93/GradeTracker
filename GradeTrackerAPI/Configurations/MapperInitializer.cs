namespace GradeTrackerAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<EducationType, EducationTypeDto>().ReverseMap();
            CreateMap<CompetenceArea, CompetenceAreaDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
}
