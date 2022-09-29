
namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ModuleController> _logger;
        private readonly IMapper _mapper;

        public ModuleController(IUnitOfWork unitOfWork, ILogger<ModuleController> logger, IMapper mapper)
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
                var modules = await _unitOfWork.Modules.GetAll();
                var results = _mapper.Map<IList<ModuleDto>>(modules);
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
                var module = await _unitOfWork.Modules.Get(e => e.Id == id, new List<string> { "Marks"});
                var result = _mapper.Map<ModuleDto>(module);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error {nameof(GetById)}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateModuleDto request)
        {
            var module = _mapper.Map<Module>(request);
            await _unitOfWork.Modules.Insert(module);
            await _unitOfWork.Save();

            return Ok(module);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateModuleDto request)
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

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var module = await _unitOfWork.Modules.Get(e => e.Id == id);
            if (module == null)
            {
                return BadRequest("Error");
            }

            await _unitOfWork.Modules.Delete(id);
            await _unitOfWork.Save();

            return Ok("Module deleted");
        }
    }
}
