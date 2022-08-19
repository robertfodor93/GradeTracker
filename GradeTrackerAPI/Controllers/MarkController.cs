using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MarkController> _logger;
        private readonly IMapper _mapper;

        public MarkController(IUnitOfWork unitOfWork, ILogger<MarkController> logger, IMapper mapper)
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
                var marks = await _unitOfWork.Marks.GetAll();
                var results = _mapper.Map<IList<MarkDto>>(marks);
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
                var mark = await _unitOfWork.Marks.Get(e => e.Id == id);
                var result = _mapper.Map<MarkDto>(mark);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(GetById)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] MarkDto request)
        {
            var mark = _mapper.Map<Mark>(request);
            await _unitOfWork.Marks.Insert(mark);
            await _unitOfWork.Save();

            return Ok(mark);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] MarkDto request)
        {
            var mark = await _unitOfWork.Marks.Get(e => e.Id == id);
            if (mark == null)
            {
                return BadRequest("Error");
            }

            _mapper.Map(request, mark);
            _unitOfWork.Marks.Update(mark);
            await _unitOfWork.Save();

            return Ok(mark);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var mark = await _unitOfWork.Marks.Get(e => e.Id == id);
            if (mark == null)
            {
                return BadRequest("Error");
            }

            await _unitOfWork.Marks.Delete(id);
            await _unitOfWork.Save();

            return Ok("Mark deleted");
        }
    }
}
