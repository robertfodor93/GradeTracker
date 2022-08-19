using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TeacherController> _logger;
        private readonly IMapper _mapper;

        public TeacherController(IUnitOfWork unitOfWork, ILogger<TeacherController> logger, IMapper mapper)
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
                var teachers = await _unitOfWork.Teachers.GetAll();
                var results = _mapper.Map<IList<TeacherDto>>(teachers);
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
                var teacher = await _unitOfWork.Teachers.Get(e => e.Id == id);
                var result = _mapper.Map<TeacherDto>(teacher);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(GetById)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TeacherDto request)
        {
            var teacher = _mapper.Map<Teacher>(request);
            await _unitOfWork.Teachers.Insert(teacher);
            await _unitOfWork.Save();

            return Ok(teacher);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] TeacherDto request)
        {
            var teacher = await _unitOfWork.Teachers.Get(e => e.Id == id);
            if (teacher == null)
            {
                return BadRequest("Error");
            }

            _mapper.Map(request, teacher);
            _unitOfWork.Teachers.Update(teacher);
            await _unitOfWork.Save();

            return Ok(teacher);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _unitOfWork.Teachers.Get(e => e.Id == id);
            if (teacher == null)
            {
                return BadRequest("Error");
            }

            await _unitOfWork.Teachers.Delete(id);
            await _unitOfWork.Save();

            return Ok("Teacher deleted");
        }
    }
}
