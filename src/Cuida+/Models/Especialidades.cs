using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models
{
    [Table("especialidades")]
    public class Especialidades
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("crm")]
        public string crm { get; set; }
    }
}