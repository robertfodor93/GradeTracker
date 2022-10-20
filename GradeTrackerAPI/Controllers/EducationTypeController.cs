using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationTypeController : ControllerBase
    {
        private readonly IEducationTypesRepository _educationTypesRepository;
        private readonly ILogger<EducationTypeController> _logger;
        private readonly IMapper _mapper;

        public EducationTypeController(IEducationTypesRepository educationTypesRepository, ILogger<EducationTypeController> logger, IMapper mapper)
        {
            this._educationTypesRepository = educationTypesRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IReadOnlyList<GetEducationTypeDTO>>> GetAll()
        {
            var educationTypes = await _educationTypesRepository.GetDetails();
            var records = _mapper.Map<IReadOnlyList<GetEducationTypeDTO>>(educationTypes);
            return Ok(records);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<GetEducationTypeDTO>> GetById(int id)
        {
            var educationType = await _educationTypesRepository.GetDetail(id);

            if (educationType == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            var educationTypeDTO = _mapper.Map<GetEducationTypeDTO>(educationType);

            return Ok(educationTypeDTO);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<EducationType>> Create([FromBody] CreateEducationTypeDTO createEducationTypeDTO)
        {
            var educationType = _mapper.Map<EducationType>(createEducationTypeDTO);
            await _educationTypesRepository.AddAsync(educationType);
            return CreatedAtAction("GetById", new { id = educationType.Id }, educationType);

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEducationTypeDTO updateEducationTypeDTO)
        {
            if (id != updateEducationTypeDTO.Id)
            {
                return BadRequest("Invalid ID");
            }

            var educationType = await _educationTypesRepository.GetAsync(id);

            if (educationType == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            _mapper.Map(updateEducationTypeDTO, educationType);

            try
            {
                await _educationTypesRepository.UpdateAsync(educationType);
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
            var teacher = await _educationTypesRepository.GetAsync(id);

            if (teacher == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            await _educationTypesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ModuleExists(int id)
        {
            return await _educationTypesRepository.Exists(id);
        }
    }
}
