using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apixmlwin.Models
{
    [Table("t_reglas")]
    public class intermediaMensaje
    {
        [Key]
        public int id { get; set; }
        public string? codigo { get; set; }
        public string regla { get; set; }
    }
}
