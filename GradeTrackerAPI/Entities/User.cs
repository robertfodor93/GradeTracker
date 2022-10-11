namespace GradeTrackerAPI.Entities
{
    public class User : IdentityUser
    {
        public List <EducationTypeGoal>? EducationTypeGoals { get; set; }
        public List<Module>? Modules { get; set; }
    }
}
