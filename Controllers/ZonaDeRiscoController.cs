using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeZone.API.Data;
using SafeZone.API.DTOs;
using SafeZone.API.Models;
using Swashbuckle.AspNetCore.Annotations;


namespace SafeZone.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonaDeRiscoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ZonaDeRiscoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as zonas de risco cadastradas com seus moradores e alertas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ZonaDeRisco>>> GetAll()
        {
            return await _context.ZonasDeRisco
                .Include(z => z.Moradores)
                .Include(z => z.Alertas)
                .ToListAsync();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova zona de risco no sistema")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(ZonaDeRiscoDTO dto)
        {
            var zona = new ZonaDeRisco
            {
                Nome = dto.Nome,
                TipoEvento = dto.TipoEvento,
                Status = dto.Status,
                Coordenadas = dto.Coordenadas
            };

            _context.ZonasDeRisco.Add(zona);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = zona.Id }, zona);
        }
    }
}