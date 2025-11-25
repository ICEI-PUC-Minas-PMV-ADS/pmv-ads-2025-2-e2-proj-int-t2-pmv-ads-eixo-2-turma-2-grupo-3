using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.Registros
{
    [Table("CRM")]
    [Index(nameof(Numero), IsUnique = true)]
    public class CRM
    {
        [Key]
        public int Id { get; set; }

        [StringLength(8, MinimumLength = 8)]
        public string Numero { get; set; }
    }
}
