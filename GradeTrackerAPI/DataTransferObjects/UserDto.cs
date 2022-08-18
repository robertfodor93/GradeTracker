namespace GradeTrackerAPI.DataTransferObjects
{
    public class UserDto
    {
        public virtual IList<ModuleDto> Modules { get; set; }
    }

    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
