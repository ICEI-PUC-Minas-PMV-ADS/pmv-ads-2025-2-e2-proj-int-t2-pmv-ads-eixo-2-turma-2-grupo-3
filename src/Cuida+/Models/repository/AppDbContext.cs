using Microsoft.EntityFrameworkCore;
<<<<<<< Updated upstream
=======
using Cuida_.Models.usuarios;
using Cuida_.Models.campanhas;
>>>>>>> Stashed changes

namespace Cuida_.Models.repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
<<<<<<< Updated upstream
        
        public DbSet<usuarios.Usuario> Usuarios { get; set; }
        public DbSet<usuarios.Paciente> Pacientes { get; set; }
        public DbSet<usuarios.Medico> Medicos { get; set; }
        public DbSet<usuarios.Clinica> Clinicas { get; set; }
        public DbSet<campanhas.Campanha> Campanhas { get; set; }
=======

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Paciente> Pacientes { get; set; } = null!;
        public DbSet<Medico> Medicos { get; set; } = null!;
        public DbSet<Clinica> Clinicas { get; set; } = null!;
        public DbSet<Campanha> Campanhas { get; set; } = null!;
        public DbSet<CampanhasAderidas.AderirCampanhas> AderirCampanhas { get; set; } = null!;
        public DbSet<MedicoCampanha> MedicoCampanhas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MedicoCampanha>(entity =>
            {
                entity.ToTable("MedicoCampanha");

                entity.HasKey(mc => mc.Id);

                entity.HasOne(mc => mc.Medico)
                      .WithMany(m => m.MedicoCampanhas)
                      .HasForeignKey(mc => mc.MedicoId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mc => mc.Campanha)
                      .WithMany(c => c.MedicoCampanhas)
                      .HasForeignKey(mc => mc.CampanhaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(mc => new { mc.MedicoId, mc.CampanhaId }).IsUnique();
            });
        }
>>>>>>> Stashed changes
    }
}
