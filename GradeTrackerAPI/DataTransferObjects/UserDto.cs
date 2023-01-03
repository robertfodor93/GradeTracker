namespace GradeTrackerAPI.DataTransferObjects
{
    public class UserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class ChangePasswordDto
    {
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
