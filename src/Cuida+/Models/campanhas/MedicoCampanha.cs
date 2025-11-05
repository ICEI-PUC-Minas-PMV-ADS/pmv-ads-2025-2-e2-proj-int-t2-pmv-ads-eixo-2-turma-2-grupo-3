using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cuida_.Models.usuarios;

namespace Cuida_.Models.campanhas
{
    [Table("MedicoCampanha")]
    public class MedicoCampanha
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Medico))]
        public int MedicoId { get; set; }

        [Required]
        [ForeignKey(nameof(Campanha))]
        public int CampanhaId { get; set; }

        public Medico Medico { get; set; } = null!;
        public Campanha Campanha { get; set; } = null!;
    }
}
