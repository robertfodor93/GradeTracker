
namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDto request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserDto request)
        {
            var response = await _authService.Login(request);
            if(response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var response = await _authService.RefreshToken();
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<string> Authorization()
        {
            return Ok("Authorized");
        }
    }
}
