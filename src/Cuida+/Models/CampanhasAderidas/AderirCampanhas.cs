using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.CampanhasAderidas
{
    
    [Table("AderirCampanhas")]
    public class AderirCampanhas
    {

        [Key]

        public int Id { get; set; }
       
        [Required(ErrorMessage = "Id da campanha obrigatório")]
        public int CampanhaId { get; set; }
       
        [Required(ErrorMessage = "Id do usuário obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Data de adesão obrigatória")]
        public DateTime DataAdericao { get; set; }

        [Required(ErrorMessage = "Status da adesão obrigatório")]
        public string Status { get; set; }
        
        [Required(ErrorMessage = "Observações obrigatórias")]
        public string Observation { get; set; }
        
        [Required(ErrorMessage = "Data de conclusão obrigatória")]
        public DateTime DataConclusao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Resultado obrigatório")]
        public string Resultado { get; set; }
        
        [Required(ErrorMessage = "Feedback obrigatório")]
        public string Feedback { get; set; }



    }




    }

    


