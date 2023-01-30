using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDTO userDTO)
        {
            var response = await _authRepository.Register(userDTO);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            var response = await _authRepository.Login(loginUserDTO);
            if (response == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var response = await _authRepository.RefreshToken();
            if (response == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
