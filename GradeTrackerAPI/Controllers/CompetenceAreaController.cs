using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceAreaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CompetenceAreaController> _logger;
        private readonly IMapper _mapper;

        public CompetenceAreaController(IUnitOfWork unitOfWork, ILogger<CompetenceAreaController> logger, IMapper mapper)
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
                var competenceAreas = await _unitOfWork.CompetenceAreas.GetAll();
                var results = _mapper.Map<IList<CompetenceAreaDto>>(competenceAreas);
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
                var competenceArea = await _unitOfWork.CompetenceAreas.Get(e => e.Id == id);
                var result = _mapper.Map<CompetenceAreaDto>(competenceArea);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(GetById)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CompetenceAreaDto request)
        {
            var competenceArea = _mapper.Map<CompetenceArea>(request);
            await _unitOfWork.CompetenceAreas.Insert(competenceArea);
            await _unitOfWork.Save();

            return Ok(competenceArea);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] CompetenceAreaDto request)
        {
            var competenceArea = await _unitOfWork.CompetenceAreas.Get(e => e.Id == id);
            if (competenceArea == null)
            {
                return BadRequest("Error");
            }

            _mapper.Map(request, competenceArea);
            _unitOfWork.CompetenceAreas.Update(competenceArea);
            await _unitOfWork.Save();

            return Ok(competenceArea);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var competenceArea = await _unitOfWork.CompetenceAreas.Get(e => e.Id == id);
            if (competenceArea == null)
            {
                return BadRequest("Error");
            }

            await _unitOfWork.CompetenceAreas.Delete(id);
            await _unitOfWork.Save();

            return Ok("Competence Area deleted");
        }
    }
}
