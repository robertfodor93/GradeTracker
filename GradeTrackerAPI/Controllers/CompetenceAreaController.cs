using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenceAreaController : ControllerBase
    {
        private readonly ICompetenceAreasRepository _competenceAreasRepository;
        private readonly ILogger<CompetenceAreaController> _logger;
        private readonly IMapper _mapper;

        public CompetenceAreaController(ICompetenceAreasRepository competenceAreasRepository, ILogger<CompetenceAreaController> logger, IMapper mapper)
        {
            this._competenceAreasRepository = competenceAreasRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<GetCompetenceAreaDTO>>> GetAll()
        {
            var competenceAreas = await _competenceAreasRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCompetenceAreaDTO>>(competenceAreas);
            return Ok(records);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<GetCompetenceAreaDTO>> GetById(int id)
        {
            var competenceArea = await _competenceAreasRepository.GetAsync(id);

            if (competenceArea == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            var competenceAreaDTO = _mapper.Map<GetCompetenceAreaDTO>(competenceArea);

            return Ok(competenceAreaDTO);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CompetenceArea>> Create([FromBody] CreateCompetenceAreaDTO createCompetenceAreaDTO)
        {
            var competenceArea = _mapper.Map<CompetenceArea>(createCompetenceAreaDTO);
            await _competenceAreasRepository.AddAsync(competenceArea);
            return CreatedAtAction("GetById", new { id = competenceArea.Id }, competenceArea);

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCompetenceAreaDTO updateCompetenceAreaDTO)
        {
            if (id != updateCompetenceAreaDTO.Id)
            {
                return BadRequest("Invalid ID");
            }

            var competenceArea = await _competenceAreasRepository.GetAsync(id);

            if (competenceArea == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            _mapper.Map(updateCompetenceAreaDTO, competenceArea);

            try
            {
                await _competenceAreasRepository.UpdateAsync(competenceArea);
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
            var competenceArea = await _competenceAreasRepository.GetAsync(id);

            if (competenceArea == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            await _competenceAreasRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ModuleExists(int id)
        {
            return await _competenceAreasRepository.Exists(id);
        }
    }
}
