using System.Collections.Generic;
using Cuida_.Models.usuarios;

namespace Cuida_Models
{
    public class ConsultaViewModel
    {
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Horario { get; set; }

        public List<Paciente> Pacientes { get; set; }
        public List<Medico> Medicos { get; set; }
    }
}