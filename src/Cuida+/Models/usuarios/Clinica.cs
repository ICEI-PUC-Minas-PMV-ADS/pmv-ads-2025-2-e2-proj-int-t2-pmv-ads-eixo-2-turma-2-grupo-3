using Microsoft.EntityFrameworkCore;
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
        [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ deve conter exatamente 14 dígitos (somente números).")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CNPJ deve ter exatamente 14 caracteres.")]
        public string CNPJ { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}