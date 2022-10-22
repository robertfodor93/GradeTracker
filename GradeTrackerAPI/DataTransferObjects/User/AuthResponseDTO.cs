namespace GradeTrackerAPI.DataTransferObjects.User
{
    public class AuthResponseDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenExpires { get; set; }
    }
}
