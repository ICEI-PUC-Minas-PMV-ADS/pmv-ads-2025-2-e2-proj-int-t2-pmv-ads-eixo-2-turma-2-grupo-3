using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.Registros
{
    [Table("Cadunico")]
    [Index(nameof(Numero), IsUnique = true)]
    public class CadUnico
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string Numero { get; set; }
    }
}
