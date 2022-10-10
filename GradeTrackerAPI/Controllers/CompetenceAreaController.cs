using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceAreaController : ControllerBase
    {
        private readonly ILogger<CompetenceAreaController> _logger;
        private readonly IMapper _mapper;

        public CompetenceAreaController(ILogger<CompetenceAreaController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}
