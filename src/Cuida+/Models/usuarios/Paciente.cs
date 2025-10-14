using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.usuarios
{
    [Table("Pacientes")]
    public class Paciente : Usuario
    {
        [Required(ErrorMessage = "CPF obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Cadastro Único obrigatório")]
        public int CadUnico { get; set; }
    }
}
