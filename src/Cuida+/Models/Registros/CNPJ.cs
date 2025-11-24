using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cuida_.Models.Registros
{
    [Table("CNPJ")]
    [Index(nameof(Numero), IsUnique = true)]
    public class CNPJ
    {
        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
    }
}
