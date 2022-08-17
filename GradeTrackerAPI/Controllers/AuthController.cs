using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        private readonly DataContext _dataContext;

        public AuthController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            user.Username = request.Username;
            user.Password = request.Password;
            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var dbUser = await _dataContext.Users.Where(u => u.Username == request.Username && u.Password == request.Password).FirstOrDefaultAsync();

            if(dbUser == null)
            {
                return BadRequest("Login error");
            }

            return Ok(dbUser);
        }
    }
}
