using AutoMapper;
using Floorplan.Dtos;
using Floorplan.models;
using Floorplan.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Floorplan.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorplansController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public FloorplansController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromForm] FloorplanCreateDto dto, // <-- belangrijk: FromForm
            CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);
            
            var entity = _mapper.Map<FloorplanModel>(dto);
            
            if (dto.Image is not null && dto.Image.Length > 0)
            {
                using var ms = new MemoryStream();
                await dto.Image.CopyToAsync(ms, ct);
                entity.Image = ms.ToArray();
                entity.ImageContentType = dto.Image.ContentType; // bv. image/png
            }

            await _db.Floorplans.AddAsync(entity, ct);
            await _db.SaveChangesAsync(ct);

            var readDto = _mapper.Map<FloorplanReadDto>(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, readDto);
        }
        
        // READ ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorplanReadDto>>> GetAll(CancellationToken ct)
        {
            var items = await _db.Floorplans.AsNoTracking().ToListAsync(ct);
            var dtoList = _mapper.Map<List<FloorplanReadDto>>(items);
            return Ok(dtoList);
        }

        // READ BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var entity = await _db.Floorplans.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id, ct);
            if (entity is null) return NotFound();

            var readDto = _mapper.Map<FloorplanReadDto>(entity);
            return Ok(readDto);
        }

        // UPDATE
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromForm] FloorplanCreateDto dto, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var entity = await _db.Floorplans.FirstOrDefaultAsync(f => f.Id == id, ct);
            if (entity is null)
                return NotFound();
            
            _mapper.Map(dto, entity);
            
            if (dto.Image is not null && dto.Image.Length > 0)
            {
                if (dto.Image.Length > 5 * 1024 * 1024)
                    return BadRequest("Image too large (max 5MB).");

                var allowedTypes = new[] { "image/png", "image/jpeg", "image/webp" };
                if (!allowedTypes.Contains(dto.Image.ContentType))
                    return BadRequest("Unsupported image type.");

                using var ms = new MemoryStream();
                await dto.Image.CopyToAsync(ms, ct);
                entity.Image = ms.ToArray();
                entity.ImageContentType = dto.Image.ContentType;
            }

            await _db.SaveChangesAsync(ct);
            return NoContent();
        }


        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var entity = await _db.Floorplans.FirstOrDefaultAsync(f => f.Id == id, ct);
            if (entity is null) return NotFound();

            _db.Floorplans.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}
