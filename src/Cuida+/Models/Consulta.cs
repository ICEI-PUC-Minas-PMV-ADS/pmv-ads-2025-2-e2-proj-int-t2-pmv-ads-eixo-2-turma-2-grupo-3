using Cuida_.Models.Usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models
{
    public class Consulta

    {
        [Key]
        public int IdConsulta { get; set; }
        
        [Required]
        [ForeignKey(nameof(Paciente))]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        
        [Required]
        [ForeignKey(nameof(Medico))]
        public int? MedicoId { get; set; }
        public Medico Medico { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Horario { get; set; }

    }
}
