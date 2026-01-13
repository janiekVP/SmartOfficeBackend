using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POISensor.Dtos;
using POISensor.Data;
using POISensor.models;

namespace POISensor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class POISensorController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public POISensorController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] POISensorCreateDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            // Valdeer POIId
            
            var entity = _mapper.Map<POISensorModel>(dto);
            await _db.POISensors.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);

            var readDto = _mapper.Map<POISensorReadDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, readDto);
        }

        // READ ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<POISensorReadDto>>> GetAll(CancellationToken ct)
        {
            var items = await _db.POISensors.AsNoTracking().ToListAsync(ct);
            return Ok(_mapper.Map<List<POISensorReadDto>>(items));
        }

        // READ BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _db.POISensors.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, ct);
            if (entity is null) return NotFound();

            return Ok(_mapper.Map<POISensorReadDto>(entity));
        }

        // UPDATE
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] POISensorCreateDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var entity = await _db.POISensors.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (entity is null) return NotFound();

            // Valideer POIId
            
            _mapper.Map(dto, entity);
            await _db.SaveChangesAsync(ct);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var entity = await _db.POISensors.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (entity is null) return NotFound();

            _db.POISensors.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}
