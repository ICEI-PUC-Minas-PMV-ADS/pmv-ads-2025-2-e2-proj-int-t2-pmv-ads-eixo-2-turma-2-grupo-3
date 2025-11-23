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
        public string CNPJ { get; set; }

        // PROPRIEDADE REMOVIDA: public int? ClinicaId { get; set; }

        // NOVO: Chave Estrangeira explícita para o Usuario (FK)
        // Isso garante que a FK seja criada na tabela Clinicas, e não Usuarios.
        public int UsuarioId { get; set; }

        // Propriedade de navegação de volta para Usuario
        public Usuario Usuario { get; set; }
    }
}