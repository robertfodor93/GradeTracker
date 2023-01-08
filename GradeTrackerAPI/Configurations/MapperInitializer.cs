using GradeTrackerAPI.DataTransferObjects;

namespace GradeTrackerAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Module, BaseModuleDTO>().ReverseMap();
            CreateMap<Module, CreateModuleDTO>().ReverseMap();
            CreateMap<Module, GetModuleDTO>().ReverseMap();
            CreateMap<Module, UpdateModuleDTO>().ReverseMap();
            CreateMap<Module, ModuleDTO>().ReverseMap();

            CreateMap<Mark, BaseMarkDTO>().ReverseMap();
            CreateMap<Mark, CreateMarkDTO>().ReverseMap();
            CreateMap<Mark, GetMarkDTO>().ReverseMap();
            CreateMap<Mark, UpdateMarkDTO>().ReverseMap();
            CreateMap<Mark, MarkDTO>().ReverseMap();

            CreateMap<Teacher, BaseTeacherDTO>().ReverseMap();
            CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, GetTeacherDTO>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();
            CreateMap<Teacher, TeacherDTO>().ReverseMap();

            CreateMap<CompetenceArea, BaseCompetenceAreaDTO>().ReverseMap();
            CreateMap<CompetenceArea, CreateCompetenceAreaDTO>().ReverseMap();
            CreateMap<CompetenceArea, GetCompetenceAreaDTO>().ReverseMap();
            CreateMap<CompetenceArea, UpdateCompetenceAreaDTO>().ReverseMap();
            CreateMap<CompetenceArea, CompetenceAreaDTO>().ReverseMap();

            CreateMap<EducationType, BaseEducationTypeDTO>().ReverseMap();
            CreateMap<EducationType, CreateEducationTypeDTO>().ReverseMap();
            CreateMap<EducationType, GetEducationTypeDTO>().ReverseMap();
            CreateMap<EducationType, UpdateEducationTypeDTO>().ReverseMap();
            CreateMap<EducationType, EducationTypeDTO>().ReverseMap();

            CreateMap<EducationTypeGoal, BaseEducationTypeGoalDTO>().ReverseMap();
            CreateMap<EducationTypeGoal, CreateEducationTypeGoalDTO>().ReverseMap();
            CreateMap<EducationTypeGoal, GetEducationTypeGoalDTO>().ReverseMap();
            CreateMap<EducationTypeGoal, UpdateEducationTypeGoalDTO>().ReverseMap();
            CreateMap<EducationTypeGoal, EducationTypeGoalDTO>().ReverseMap();

            CreateMap<User, BaseUserDTO>().ReverseMap();
            CreateMap<User, GetUserDTO>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
