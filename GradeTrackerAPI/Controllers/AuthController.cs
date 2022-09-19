
namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] UserDto request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserDto request)
        {
            var response = await _authService.Login(request);
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPost("changePassword")]
        public async Task<ActionResult<User>> ChangePassword(int id, [FromBody]ChangePasswordDto request)
        {
            var response = await _authService.ChangePassword(id, request);

            return response;
        }

        [HttpPost("refreshToken")]
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
