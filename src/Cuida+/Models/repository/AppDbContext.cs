using Microsoft.EntityFrameworkCore;

namespace Cuida_.Models.repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<usuarios.Usuario> Usuarios { get; set; }
        public DbSet<usuarios.Paciente> Pacientes { get; set; }
        public DbSet<usuarios.Medico> Medicos { get; set; }
        public DbSet<usuarios.Clinica> Clinicas { get; set; }
    }
}
