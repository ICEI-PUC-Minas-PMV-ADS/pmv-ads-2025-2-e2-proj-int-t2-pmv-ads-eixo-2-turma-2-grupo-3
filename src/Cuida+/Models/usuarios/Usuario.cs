using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.Usuarios
{
    // Enum para identificar o tipo de usuário
    public enum TipoUsuario
    {
        Paciente,
        Medico,
        Clinica
    }

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

        // PROPRIEDADE RESTAURADA: Esta é a coluna STRING que existe no seu DB.
        public string TipoRegistro { get; set; }

        public string Nome { get; set; }

        // PROPRIEDADE ADICIONADA: Esta é a nova coluna ENUM/INT que o EF Core tentará criar.
        public TipoUsuario? TipoUsuario { get; set; }


        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Clinica Clinica { get; set; }
    }
}