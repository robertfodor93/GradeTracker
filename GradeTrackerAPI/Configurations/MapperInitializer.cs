namespace GradeTrackerAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<EducationTypeGoal, EducationTypeGoalDto>().ReverseMap();
            CreateMap<EducationType, EducationTypeDto>().ReverseMap();
            CreateMap<CompetenceArea, CompetenceAreaDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, CreateModuleDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Mark, MarkDto>().ReverseMap();
        }
    }
}
