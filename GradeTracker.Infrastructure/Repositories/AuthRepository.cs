using GradeTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthRepository(DataContext dataContext, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
        }

        public async Task<User> Register(UserDTO userDTO)
        {
            CreatePasswordHash(userDTO.Password, out byte[] passwordSalt, out byte[] passwordHash);

            var user = new User
            {
                Username = userDTO.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        public async Task<AuthResponseDTO> Login(LoginUserDTO loginUserDTO)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Username == loginUserDTO.Username);
            if (user == null)
            {
                return new AuthResponseDTO { Message = "User not found." };
            }

            if (!VerifyPasswordHash(loginUserDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new AuthResponseDTO { Message = "Wrong Password." };
            }

            string token = GenerateToken(user);
            var refreshToken = CreateRefreshToken();
            await SetRefreshToken(refreshToken, user);

            return new AuthResponseDTO
            {
                Id = user.Id,
                Username = user.Username,
                Token = token,
                RefreshToken = refreshToken.Token,
                TokenExpires = refreshToken.Expires
            };
        }

        private void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var hmac = new HMACSHA512())
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

        private string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<AuthResponseDTO> RefreshToken()
        {
            var refreshToken = _httpContextAccessor?.HttpContext?.Request.Cookies["refreshToken"];
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user == null)
            {
                return new AuthResponseDTO { Message = "Invalid Refresh Token" };
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return new AuthResponseDTO { Message = "Token expired." };
            }

            string token = GenerateToken(user);
            var newRefreshToken = CreateRefreshToken();
            await SetRefreshToken(newRefreshToken, user);

            return new AuthResponseDTO
            {
                Token = token,
                RefreshToken = newRefreshToken.Token,
                TokenExpires = newRefreshToken.Expires
            };
        }

        private RefreshToken CreateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private async Task SetRefreshToken(RefreshToken refreshToken, User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
            };
            _httpContextAccessor?.HttpContext?.Response
                .Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpires = refreshToken.Expires;

            await _dataContext.SaveChangesAsync();
        }
    }
}
