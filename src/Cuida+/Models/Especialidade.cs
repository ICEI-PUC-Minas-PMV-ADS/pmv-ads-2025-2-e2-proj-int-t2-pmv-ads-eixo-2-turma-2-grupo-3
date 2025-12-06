using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models
{
    [Table("Especialidades")]
    public class Especialidade
    {
        [Key]
        public int Id { get; set; }
        public string Nomenclatura { get; set; }
    }
}