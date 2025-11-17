using Cuida_.Models;
using Cuida_.Models.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Cuida_.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔥 Forçar exatamente o nome Tabela/Coluna igual ao MySQL
            modelBuilder.Entity<Medico>().ToTable("Medicos");
            
            modelBuilder.Entity<Medico>()
                .Property(m => m.UsuarioId)
                .HasColumnName("UsuarioId");
        }
    }
}
