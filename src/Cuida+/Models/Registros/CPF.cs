using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.Registros
{
    [Table("CPF")]
    [Index(nameof(Numero), IsUnique = true)]
    public class CPF
    {
        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
    }
}
