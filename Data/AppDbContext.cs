using Microsoft.EntityFrameworkCore;
using SafeZone.API.Models;

namespace SafeZone.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ZonaDeRisco> ZonasDeRisco { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Morador> Moradores { get; set; }
        public DbSet<KitEmergencia> KitsEmergencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ZonaDeRisco>()
                .HasMany(z => z.Alertas)
                .WithOne(a => a.ZonaDeRisco!)
                .HasForeignKey(a => a.ZonaDeRiscoId);
            
            modelBuilder.Entity<ZonaDeRisco>()
                .HasMany(z => z.Moradores)
                .WithOne(m => m.ZonaDeRisco!)
                .HasForeignKey(m => m.ZonaDeRiscoId);
        }
    }
}