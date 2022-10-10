using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationTypeGoalController : ControllerBase
    {
        private readonly ILogger<EducationTypeGoalController> _logger;
        private readonly IMapper _mapper;

        public EducationTypeGoalController(ILogger<EducationTypeGoalController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
