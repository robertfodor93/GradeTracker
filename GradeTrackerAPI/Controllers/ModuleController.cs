
namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModulesRepository _modulesRepository;
        private readonly ILogger<ModuleController> _logger;
        private readonly IMapper _mapper;

        public ModuleController(IModulesRepository modulesRepository, ILogger<ModuleController> logger, IMapper mapper)
        {
            this._modulesRepository = modulesRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet("getAll")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<GetModuleDTO>>> GetAll()
        {
            var modules = await _modulesRepository.GetDetails();
            var records = _mapper.Map<List<GetModuleDTO>>(modules);
            return Ok(records);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<GetModuleDTO>> GetById(int id)
        {
            var module = await _modulesRepository.GetDetail(id);

            if(module == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            var moduleDTO = _mapper.Map<ModuleDTO>(module);

            return Ok(moduleDTO);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Module>> Create([FromBody] CreateModuleDTO createModuleDTO)
        {
            var module = _mapper.Map<Module>(createModuleDTO);
            await _modulesRepository.AddAsync(module);
            return CreatedAtAction("GetById", new { id = module.Id }, module);

        }

        [HttpPatch("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateModuleDTO updateModuleDTO)
        {
            if(id != updateModuleDTO.Id)
            {
                return BadRequest("Invalid ID");
            }

            var module = await _modulesRepository.GetAsync(id);

            if(module == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            _mapper.Map(updateModuleDTO, module);

            try
            {
                await _modulesRepository.UpdateAsync(module);
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!await ModuleExists(id))
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

        /* Needs revision
        [HttpPut("setGoal")]
        public async Task<IActionResult> SetGoal(int id, [FromBody] SetGoalDto request)
        {
            var module = await _unitOfWork.Modules.Get(e => e.Id == id);
            if (module == null)
            {
                return BadRequest("Error");
            }

            _mapper.Map(request, module);
            _unitOfWork.Modules.Update(module);
            await _unitOfWork.Save();

            return Ok(module);
        }
        */

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var module = await _modulesRepository.GetAsync(id);

            if(module == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            await _modulesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> ModuleExists(int id)
        {
            return await _modulesRepository.Exists(id);
        }
    }
}
