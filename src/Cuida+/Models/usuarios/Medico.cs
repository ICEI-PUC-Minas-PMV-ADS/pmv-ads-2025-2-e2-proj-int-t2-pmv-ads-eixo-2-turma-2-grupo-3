using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Cuida_.Models.Usuarios
{
    [Table("Medicos")]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CRM é obrigatório.")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Especialidade obrigatória")]
        public string Especialidade { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        // Relação many-to-many com Campanha (campanhas em que o médico aderiu)
        public ICollection<Cuida_.Models.Campanha> Campanhas { get; set; } = new List<Cuida_.Models.Campanha>();
    }
}