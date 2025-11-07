using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.Usuarios
{
    [Table("Usuarios")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "E-mail obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        public string Senha { get; set; }
        public string TipoRegistro { get; set; }
    }
}
