using Cuida_.Models;
using Cuida_.Models.Registros;
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
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<CPF> CPFs { get; set; }
        public DbSet<CRM> CRMs { get; set; }
        public DbSet<CNPJ> CNPJs { get; set; }
    }
}
