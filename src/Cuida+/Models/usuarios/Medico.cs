using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.usuarios
{
    [Table("Medicos")]
    public class Medico : Usuario
    {
        [Required(ErrorMessage = "CRM obrigatório")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "Especialidade obrigatória")]
        public string Especialidade { get; set; }

        public List<string> HorariosDisponiveis { get; set; }
    }
}