namespace GradeTrackerAPI.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(UserDto request);
        Task<AuthResponseDto> Login(UserDto request);
    }
}
