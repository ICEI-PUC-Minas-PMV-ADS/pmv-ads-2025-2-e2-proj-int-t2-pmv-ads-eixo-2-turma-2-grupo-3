using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.usuarios
{
    [Table("Clinicas")]
    public class Clinica : Usuario
    {
        [Required(ErrorMessage = "Nome Fantasia obrigatório")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string Cnpj { get; set; }
    }
}
