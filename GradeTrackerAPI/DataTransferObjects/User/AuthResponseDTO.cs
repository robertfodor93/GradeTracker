namespace GradeTrackerAPI.DataTransferObjects.User
{
    public class AuthResponseDTO
    {
        public string UserId { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenExpires { get; set; }
    }
}
