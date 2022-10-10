using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarksRepository _marksRepository;
        private readonly ILogger<MarkController> _logger;
        private readonly IMapper _mapper;

        public MarkController(IMarksRepository marksRepository, ILogger<MarkController> logger, IMapper mapper)
        {
            _marksRepository = marksRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<GetMarkDTO>> GetAll()
        {
            var marks = await _marksRepository.GetAllAsync();
            var records = _mapper.Map<List<GetMarkDTO>>(marks);
            return Ok(records);
        }

        [HttpGet("getById{id:int}")]
        public async Task<ActionResult<GetMarkDTO>> GetById(int id)
        {
            var mark = await _marksRepository.GetAsync(id);

            if(mark == null)
            {
                throw new NotFoundException(nameof(GetById), id);
            }

            var markDTO = _mapper.Map<GetMarkDTO>(mark);

            return Ok(markDTO);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Mark>> Create([FromBody] CreateMarkDTO createMarkDTO)
        {
            var mark = _mapper.Map<Mark>(createMarkDTO);

            await _marksRepository.AddAsync(mark);

            return CreatedAtAction("GetById", new { id = mark.Id }, mark);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMarkDTO markDTO)
        {
            try
            {
                await _marksRepository.UpdateAsync(id, markDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MarkExists(id))
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
            await _marksRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> MarkExists(int id)
        {
            return await _marksRepository.Exists(id);
        }
    }
}
