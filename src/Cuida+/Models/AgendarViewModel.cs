using Cuida_.Models.Usuarios;

namespace Cuida_.Models
{
    public class AgendarViewModel
    {
        public List<DateTime> Dias { get; set; } = new();
        public List<TimeSpan> Horarios { get; set; } = new();
        public List<DateTime> SlotsOcupados { get; set; } = new();

        public Medico Medico { get; set; } = null!;
        public Campanha Campanha { get; set; } = null!;
    }
}