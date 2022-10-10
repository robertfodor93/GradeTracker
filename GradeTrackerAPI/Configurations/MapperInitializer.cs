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

            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
