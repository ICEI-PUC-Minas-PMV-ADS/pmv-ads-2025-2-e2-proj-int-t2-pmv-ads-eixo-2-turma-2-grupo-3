using System.ComponentModel.DataAnnotations;

namespace Cuida_.Models
{
    public class ConfirmarAgendamentoDto
    {
        [Required]
        public DateTime Horario { get; set; }
    }
}

