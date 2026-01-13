using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorData.Dtos;
using SensorData.Data;
using SensorData.models;

namespace SensorData.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public SensorDataController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SensorDataCreateDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            // Valideer POISensorId
         
            var entity = _mapper.Map<SensorDataModel>(dto);

            await _db.SensorData.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);

            var readDto = _mapper.Map<SensorDataReadDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, readDto);
        }

        // READ ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorDataReadDto>>> GetAll(CancellationToken ct)
        {
            var items = await _db.SensorData.AsNoTracking().ToListAsync(ct);
            var dtoList = _mapper.Map<List<SensorDataReadDto>>(items);
            return Ok(dtoList);
        }

        // READ BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _db.SensorData.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, ct);
            if (entity is null) return NotFound();

            var readDto = _mapper.Map<SensorDataReadDto>(entity);
            return Ok(readDto);
        }

        // UPDATE
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] SensorDataCreateDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var entity = await _db.SensorData.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (entity is null) return NotFound();

            // Valideer POISensorId
            
            _mapper.Map(dto, entity);
            await _db.SaveChangesAsync(ct);

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var entity = await _db.SensorData.FirstOrDefaultAsync(s => s.Id == id, ct);
            if (entity is null) return NotFound();

            _db.SensorData.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}
