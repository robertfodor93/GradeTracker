namespace GradeTrackerAPI.Entities
{
    public class User : IdentityUser
    {
        public virtual IList <EducationTypeGoal>? EducationTypeGoals { get; set; }
        public virtual IList<Module>? Modules { get; set; }
    }
}
