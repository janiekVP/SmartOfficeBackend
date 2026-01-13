using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POI.Dtos;
using POI.Data;
using POI.models;

namespace POI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class POIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public POIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] POICreateDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            // Valideer Floorplanid
            
            var entity = _mapper.Map<POIModel>(dto);

            await _db.POIs.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);

            var readDto = _mapper.Map<POIReadDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, readDto);
        }

        // READ ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<POIReadDto>>> GetAll(CancellationToken ct)
        {
            var items = await _db.POIs.AsNoTracking().ToListAsync(ct);
            var dtoList = _mapper.Map<List<POIReadDto>>(items);
            return Ok(dtoList);
        }

        // READ BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _db.POIs.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, ct);

            if (entity is null) return NotFound();

            var readDto = _mapper.Map<POIReadDto>(entity);
            return Ok(readDto);
        }

        // UPDATE
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] POICreateDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var entity = await _db.POIs.FirstOrDefaultAsync(p => p.Id == id, ct);
            if (entity is null) return NotFound();

            // Valideer FloorplanId
            
            _mapper.Map(dto, entity);
            await _db.SaveChangesAsync(ct);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var entity = await _db.POIs.FirstOrDefaultAsync(p => p.Id == id, ct);
            if (entity is null) return NotFound();

            _db.POIs.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}
