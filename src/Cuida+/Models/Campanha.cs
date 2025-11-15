using Cuida_.Models.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Cuida_.Models
{
    [Table("Campanhas")]
    public class Campanha
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da campanha obrigatório")]
        public string NomeCampanha { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data início obrigatória")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Data final obrigatória")]
        public DateTime DataFim { get; set; }
        public bool Ativa { get; set; }

        [Required]
        public int ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }

        // Relação many-to-many com Medico (lista de médicos que aderiram à campanha)
        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    }
}
