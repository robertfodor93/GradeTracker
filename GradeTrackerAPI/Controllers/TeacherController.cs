using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;
        private readonly ILogger<TeacherController> _logger;
        private readonly IMapper _mapper;

        public TeacherController(ITeachersRepository teacherRepository, ILogger<TeacherController> logger, IMapper mapper)
        {
            this._teachersRepository = teacherRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTeacherDTO>>> GetAll()
        {
            var teachers = await _teachersRepository.GetAllAsync();
            var records = _mapper.Map<List<GetTeacherDTO>>(teachers);
            return Ok(records);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<GetTeacherDTO>> GetById(int id)
        {
            var teacher = await _teachersRepository.GetAsync(id);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            var teacherDTO = _mapper.Map<GetTeacherDTO>(teacher);

            return Ok(teacherDTO);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Teacher>> Create([FromBody] CreateTeacherDTO createTeacherDTO)
        {
            var teacher = _mapper.Map<Teacher>(createTeacherDTO);
            await _teachersRepository.AddAsync(teacher);
            return CreatedAtAction("GetById", new { id = teacher.Id }, teacher);

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTeacherDTO updateTeacherDTO)
        {
            if (id != updateTeacherDTO.Id)
            {
                return BadRequest("Invalid ID");
            }

            var teacher = await _teachersRepository.GetAsync(id);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            _mapper.Map(updateTeacherDTO, teacher);

            try
            {
                await _teachersRepository.UpdateAsync(teacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ModuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teachersRepository.GetAsync(id);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            await _teachersRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ModuleExists(int id)
        {
            return await _teachersRepository.Exists(id);
        }
    }
}
