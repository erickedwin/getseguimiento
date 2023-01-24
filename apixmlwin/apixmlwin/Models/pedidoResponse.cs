using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apixmlwin.Models
{
    public class pedidoResponse
    {
        public string? Mensaje { get; set; }
        public bool Error { get; set; }
        public string? Data { get; set; }
    }
}
