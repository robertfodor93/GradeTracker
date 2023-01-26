using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Infrastructure.Config
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Module, BaseSubjectDTO>().ReverseMap();
            CreateMap<Module, CreateSubjectDTO>().ReverseMap();
            CreateMap<Module, GetSubjectDTO>().ReverseMap();
            CreateMap<Module, UpdateSubjectDTO>().ReverseMap();
            CreateMap<Module, SubjectDTO>().ReverseMap();

            CreateMap<Grade, BaseGradeDTO>().ReverseMap();
            CreateMap<Grade, CreateGradeDTO>().ReverseMap();
            CreateMap<Grade, GetGradeDTO>().ReverseMap();
            CreateMap<Grade, UpdateGradeDTO>().ReverseMap();
            CreateMap<Grade, GradeDTO>().ReverseMap();

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
