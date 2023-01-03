using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationTypeGoalController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EducationTypeGoalController> _logger;
        private readonly IMapper _mapper;

        public EducationTypeGoalController(IUnitOfWork unitOfWork, ILogger<EducationTypeGoalController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var educationTypeGoals = await _unitOfWork.EducationTypeGoals.GetAll();
                var results = _mapper.Map<IList<EducationTypeGoalDto>>(educationTypeGoals);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(GetAll)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("getById{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var educationTypeGoal = await _unitOfWork.EducationTypeGoals.Get(e => e.Id == id);
                var result = _mapper.Map<EducationTypeGoal>(educationTypeGoal);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(GetById)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EducationTypeGoalDto request)
        {
            var educationTypeGoal = _mapper.Map<EducationTypeGoal>(request);
            await _unitOfWork.EducationTypeGoals.Insert(educationTypeGoal);
            await _unitOfWork.Save();

            return Ok(educationTypeGoal);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] EducationTypeGoalDto request)
        {
            var educationTypeGoal = await _unitOfWork.EducationTypeGoals.Get(e => e.Id == id);
            if (educationTypeGoal == null)
            {
                return BadRequest("Error");
            }

            _mapper.Map(request, educationTypeGoal);
            _unitOfWork.EducationTypeGoals.Update(educationTypeGoal);
            await _unitOfWork.Save();

            return Ok(educationTypeGoal);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var educationTypeGoal = await _unitOfWork.EducationTypeGoals.Get(e => e.Id == id);
            if (educationTypeGoal == null)
            {
                return BadRequest("Error");
            }

            await _unitOfWork.EducationTypeGoals.Delete(id);
            await _unitOfWork.Save();

            return Ok("Education Type Goal deleted");
        }
    }
}
