namespace GradeTrackerAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _user;

        private const string _loginProvider = "GradeTrackerAPI";
        private const string _refreshToken = "RefreshToken";

        public AuthRepository(IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<IdentityError>> Register(UserDTO userDTO)
        {
            _user = _mapper.Map<User>(userDTO);
            _user.UserName = userDTO.Username;

            var result = await _userManager.CreateAsync(_user, userDTO.Password);

            await _userManager.AddToRoleAsync(_user, "User");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }

            return result.Errors;
        }

        public async Task<AuthResponseDTO> Login(LoginUserDTO loginUserDTO)
        {
            _user = await _userManager.FindByNameAsync(loginUserDTO.Username);
            bool isValidUser = await _userManager.CheckPasswordAsync(_user, loginUserDTO.Password);

            if (_user == null || isValidUser == false)
            {
                return null;
            }

            var token = await GenerateToken();

            return new AuthResponseDTO
            {
                Token = token,
                UserName = _user.UserName,
                Id = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };
        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:Token"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, _user.UserName),
                new Claim("uid", _user.Id),
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["AppSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);
            return newRefreshToken;
        }

        public async Task<AuthResponseDTO> VerifyRefreshToken(AuthResponseDTO request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByEmailAsync(username);

            if(_user == null || _user.Id != request.Id)
            {
                return null;
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);

            if(isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDTO
                {
                    Token = token,
                    Id = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }
    }
}
