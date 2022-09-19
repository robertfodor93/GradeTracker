namespace GradeTrackerAPI.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(UserDto request);
        Task<AuthResponseDto> Login(UserDto request);
        Task<User> ChangePassword(int id, ChangePasswordDto request);
        Task<AuthResponseDto> RefreshToken();
    }
}
