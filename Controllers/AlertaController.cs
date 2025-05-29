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
    public class AlertaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os alertas emitidos com suas respectivas zonas de risco")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAll()
        {
            return await _context.Alertas
                .Include(a => a.ZonaDeRisco)
                .ToListAsync();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Emite um novo alerta para uma zona de risco específica")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(AlertaDTO dto)
        {
            var zonaExiste = await _context.ZonasDeRisco.AnyAsync(z => z.Id == dto.ZonaDeRiscoId);
            if (!zonaExiste)
                return BadRequest("ZonaDeRiscoId inválido.");

            var alerta = new Alerta
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                NivelGravidade = dto.NivelGravidade,
                DataHora = dto.DataHora,
                ZonaDeRiscoId = dto.ZonaDeRiscoId
            };

            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = alerta.Id }, alerta);
        }
    }
}