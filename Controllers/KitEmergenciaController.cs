using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeZone.API.Data;
using SafeZone.API.Models;
using SafeZone.API.DTOs;
using Swashbuckle.AspNetCore.Annotations;



namespace SafeZone.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class KitEmergenciaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KitEmergenciaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os kits de emergência disponíveis")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<KitEmergencia>>> GetAll()
        {
            return await _context.KitsEmergencia.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarKit(int id, [FromBody] KitEmergencia kit)
        {
            if (id != kit.Id)
                return BadRequest("ID do kit não confere.");

            var kitExistente = await _context.KitsEmergencia.FindAsync(id);
            if (kitExistente == null)
                return NotFound();

            kitExistente.Tipo = kit.Tipo;
            kitExistente.Quantidade = kit.Quantidade;
            kitExistente.LocalEstoque = kit.LocalEstoque;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarKit(int id)
        {
            var kit = await _context.KitsEmergencia.FindAsync(id);
            if (kit == null)
                return NotFound();

            _context.KitsEmergencia.Remove(kit);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo kit de emergência no sistema")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(KitEmergenciaDTO dto)
        {
            var kit = new KitEmergencia
            {
                Tipo = dto.Tipo,
                Quantidade = dto.Quantidade,
                LocalEstoque = dto.LocalEstoque
            };

            _context.KitsEmergencia.Add(kit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = kit.Id }, kit);
        }
    }
}