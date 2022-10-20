
namespace GradeTrackerAPI.Controllers
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
            var errors = await _authRepository.Register(userDTO);

            if(errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginUserDTO loginUserDto)
        {
            var authResponse = await _authRepository.Login(loginUserDto);

            if(authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDTO request)
        {
            var authResponse = await _authRepository.VerifyRefreshToken(request);

            if(authResponse == null)
            {
                return Unauthorized(request);
            }

            return Ok(authResponse);
        }
    }
}
