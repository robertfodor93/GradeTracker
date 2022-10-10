namespace GradeTrackerAPI.Interfaces
{
    public interface IAuthRepository
    {
        Task<IEnumerable<IdentityError>> Register(UserDTO userDTO);
        Task<AuthResponseDTO> Login(LoginUserDTO loginUserDTO);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDTO> VerifyRefreshToken(AuthResponseDTO request);
    }
}
