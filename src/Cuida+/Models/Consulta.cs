namespace Cuida_Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Horario { get; set; }
        public string PacienteNome { get; set; }
        public string MedicoNome { get; set; }
    }
}