namespace GradeTrackerAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _dataContext;

        public AuthService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> Register(UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordSalt, out byte[] passwordHash);

            var user = new User {
                Username = request.Username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };
            
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return user;

        }

        public async Task<AuthResponseDto> Login(UserDto request)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if(user == null)
            {
                return new AuthResponseDto { Message = "Error" };
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash))
            {
                return new AuthResponseDto { Message = "Wrong credentials" };
            }

            return new AuthResponseDto { Success = true };
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
