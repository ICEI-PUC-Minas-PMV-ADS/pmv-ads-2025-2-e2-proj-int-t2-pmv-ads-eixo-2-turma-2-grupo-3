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
        [RegularExpression(@"^[A-Z]{2}\d{6}$", ErrorMessage = "CRM deve ter formato UF123456 (2 letras maiúsculas + 6 dígitos).")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "CRM deve ter exatamente 8 caracteres.")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Especialidade obrigatória")]
        public string Especialidade { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public ICollection<Cuida_.Models.Campanha> Campanhas { get; set; } = new List<Cuida_.Models.Campanha>();
    }
}