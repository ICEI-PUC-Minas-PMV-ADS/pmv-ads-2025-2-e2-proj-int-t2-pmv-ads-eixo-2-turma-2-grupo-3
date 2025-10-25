using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.usuarios
{
    [Table("Medicos")]
    public class Medico : Usuario
    {
        [Required(ErrorMessage = "O CRM é obrigatório.")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Especialidade obrigatória")]
        public string Especialidade { get; set; }
    }
}
