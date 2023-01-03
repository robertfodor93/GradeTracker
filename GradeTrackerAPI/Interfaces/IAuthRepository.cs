namespace GradeTrackerAPI.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(UserDTO userDTO);
        Task<AuthResponseDTO> Login(LoginUserDTO loginUserDTO);
        Task<AuthResponseDTO> RefreshToken();
    }
}
