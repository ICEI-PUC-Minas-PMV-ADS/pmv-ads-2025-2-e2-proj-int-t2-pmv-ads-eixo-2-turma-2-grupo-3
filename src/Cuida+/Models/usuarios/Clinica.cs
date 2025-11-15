using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.Usuarios
{
    [Table("Clinicas")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome Fantasia obrigatório")]
        public string NomeClinica { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string CNPJ { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
