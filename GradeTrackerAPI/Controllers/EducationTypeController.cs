using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EducationTypeController> _logger;
        private readonly IMapper _mapper;

        public EducationTypeController(IUnitOfWork unitOfWork, ILogger<EducationTypeController> logger, IMapper mapper)
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
                var educationTypes = await _unitOfWork.EducationTypes.GetAll();
                var results = _mapper.Map<IList<EducationTypeDto>>(educationTypes);
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
                var educationType = await _unitOfWork.EducationTypes.Get(e => e.Id == id);
                var result = _mapper.Map<EducationTypeDto>(educationType);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(GetById)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EducationTypeDto request)
        {
            var educationType = _mapper.Map<EducationType>(request);
            await _unitOfWork.EducationTypes.Insert(educationType);
            await _unitOfWork.Save();

            return Ok(educationType);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] EducationTypeDto request)
        {
            var educationType = await _unitOfWork.EducationTypes.Get(e => e.Id == id);
            if (educationType == null)
            {
                return BadRequest("Error");
            }

            _mapper.Map(request, educationType);
            _unitOfWork.EducationTypes.Update(educationType);
            await _unitOfWork.Save();

            return Ok(educationType);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var educationType = await _unitOfWork.EducationTypes.Get(e => e.Id == id);
            if (educationType == null)
            {
                return BadRequest("Error");
            }

            await _unitOfWork.EducationTypes.Delete(id);
            await _unitOfWork.Save();

            return Ok("Education Type deleted");
        }
    }
}
