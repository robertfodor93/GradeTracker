using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationTypeController : ControllerBase
    {
        private readonly ILogger<EducationTypeController> _logger;
        private readonly IMapper _mapper;

        public EducationTypeController(ILogger<EducationTypeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
