using Microsoft.AspNetCore.Mvc.RazorPages;
using SafeZone.API.Data;
using SafeZone.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SafeZone.API.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Morador> Moradores { get; set; }
        public List<ZonaDeRisco> ZonasDeRisco { get; set; }
        public List<KitEmergencia> KitsEmergencia { get; set; }
        public List<Alerta> Alertas { get; set; }

        public void OnGet()
        {
            Moradores = _context.Moradores.Include(m => m.ZonaDeRisco).ToList();
            ZonasDeRisco = _context.ZonasDeRisco.ToList();
            KitsEmergencia = _context.KitsEmergencia.ToList();
            Alertas = _context.Alertas.Include(a => a.ZonaDeRisco).ToList();
        }
    }
}