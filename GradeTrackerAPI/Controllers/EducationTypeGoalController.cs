using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationTypeGoalController : ControllerBase
    {
        private readonly IEducationTypeGoalsRepository _educationTypeGoalRepository;
        private readonly ILogger<EducationTypeGoalController> _logger;
        private readonly IMapper _mapper;

        public EducationTypeGoalController(IEducationTypeGoalsRepository educationTypeGoalRepository, ILogger<EducationTypeGoalController> logger, IMapper mapper)
        {
            _educationTypeGoalRepository = educationTypeGoalRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IReadOnlyList<GetEducationTypeGoalDTO>>> GetAll()
        {
            var educationTypes = await _educationTypeGoalRepository.GetDetails();
            var records = _mapper.Map<IReadOnlyList<GetEducationTypeGoalDTO>>(educationTypes);
            return Ok(records);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<GetEducationTypeGoalDTO>> GetById(int id)
        {
            var educationType = await _educationTypeGoalRepository.GetDetail(id);

            if (educationType == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            var educationTypeDTO = _mapper.Map<GetEducationTypeGoalDTO>(educationType);

            return Ok(educationTypeDTO);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreateEducationTypeGoalDTO>> Create([FromBody] CreateEducationTypeGoalDTO createEducationTypeGoalDTO)
        {
            var educationTypeGoal = _mapper.Map<EducationTypeGoal>(createEducationTypeGoalDTO);
            await _educationTypeGoalRepository.AddAsync(educationTypeGoal);
            var result = CreatedAtAction("GetById", new { id = educationTypeGoal.Id }, educationTypeGoal);
            return result;


        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEducationTypeGoalDTO updateEducationTypeGoalDTO)
        {
            if (id != updateEducationTypeGoalDTO.Id)
            {
                return BadRequest("Invalid ID");
            }

            var educationTypeGoal = await _educationTypeGoalRepository.GetAsync(id);

            if (educationTypeGoal == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            _mapper.Map(updateEducationTypeGoalDTO, educationTypeGoal);

            try
            {
                await _educationTypeGoalRepository.UpdateAsync(educationTypeGoal);
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
            var educationTypeGoal = await _educationTypeGoalRepository.GetAsync(id);

            if (educationTypeGoal == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            await _educationTypeGoalRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ModuleExists(int id)
        {
            return await _educationTypeGoalRepository.Exists(id);
        }
    }
}
