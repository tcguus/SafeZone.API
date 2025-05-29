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
    public class MoradorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoradorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os moradores cadastrados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Morador>>> GetAll()
        {
            return await _context.Moradores.ToListAsync();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo morador vinculado a uma zona de risco")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(MoradorDTO dto)
        {
            if (dto.CPF.Length != 11 || !dto.CPF.All(char.IsDigit))
            {
                return BadRequest("CPF inválido. Deve conter exatamente 11 números.");
            }

            var morador = new Morador
            {
                Nome = dto.Nome,
                CPF = dto.CPF,
                Prioridade = dto.Prioridade,
                ZonaDeRiscoId = dto.ZonaDeRiscoId
            };

            _context.Moradores.Add(morador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = morador.Id }, morador);
        }
    }
}