using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apixmlwin.Models
{
    [Table("CRM_PROGRAMACION", Schema = "CRM")]
    public class replicaOrdenes
    {
        [Key]
        public long PRGI_COD_PROGRAMACION { get; set; }
        public long? PRGI_COD_CLIENTE { get; set; }
        public long? PRGI_COD_DOCUMENTO { get; set; }
        public long? PRGI_COD_VENTA { get; set; }
        public string? PRGC_COD_TIPO_ESTADO { get; set; }
        public string? PRGC_COD_TIPO_MOTIVO_ESTADO { get; set; }
        public int? PRGI_NUM_INTENTO { get; set; }
        public long? PRGI_COD_PROGRAMACION_REF { get; set; }
        public DateTime? PRGD_FECHA_COMPROMISO_INSTALACION { get; set; }
        public DateTime? PRGD_FECHA_INICIO { get; set; }
        public DateTime? PRGD_HORA_INICIO { get; set; }
        public DateTime? PRGD_FECHA_FIN { get; set; }
        public DateTime? PRGD_HORA_FIN { get; set; }
        public DateTime? PRGD_FECHA_INSTALACION_REAL { get; set; }
        public string? PRGV_OBSERVACIONES { get; set; }
        public bool? PRGB_CLIENTE_CONTACTO_INSTALACION { get; set; }
        public long? PRGI_COD_CONTACTO { get; set; }
        public int? PRGI_EST_REGISTRO { get; set; }
        public string? PRGV_USUARIO_CREACION { get; set; }
        public DateTime? PRGD_FECHA_CREACION { get; set; }
        public string? PRGV_USUARIO_ACTUALIZACION { get; set; }
        public DateTime? PRGD_FECHA_ACTUALIZACION { get; set; }
        public long? PRGI_COD_PROGRAMACION_SGTE { get; set; }
        public string? PRGC_COD_TIPO_MOTIVO_OBSERVADOS { get; set; }
        public string? PRGI_FLAG_PEDIDO { get; set; }
        public long? PRGI_COD_CONTRATA { get; set; }
        public string? PRGV_CODIGO_OT_MW { get; set; }
        public string? PRGV_MAC_ROUTER { get; set; }
        public string? MENSAJEOBI { get; set; }
        public long? PRGC_COD_CIRCUITO { get; set; }
    }

    [NotMapped]
    public class ModelOrden
    {
        public long? PRGI_COD_CLIENTE { get; set; }

    }

}
