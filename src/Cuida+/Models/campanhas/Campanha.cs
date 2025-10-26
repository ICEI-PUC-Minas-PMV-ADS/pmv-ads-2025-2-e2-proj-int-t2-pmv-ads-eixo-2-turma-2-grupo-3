using Cuida_.Models.usuarios;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.campanhas
{
    [Table("Campanhas")]
    public class Campanha
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da campanha obrigatório")]
        [Display(Name = "Nome")]
        public string NomeCampanha { get; set; }

        [Required(ErrorMessage = "Descrição da campanha obrigatória")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data de início obrigatória")]
        [Display(Name = "Data de início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Data de fim obrigatória")]
        [Display(Name = "Data de finalização")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Status da campanha obrigatória")]
        public bool Ativa { get; set; } = true;


        [Required(ErrorMessage = "Clínica associada obrigatória")]
        [Display(Name = "Clínica")]
        public int ClinicaId { get; set; }

        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; } = null!;
    }
}