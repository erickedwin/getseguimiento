using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apixmlwin.Models
{
    [Table("CRM_PEDIDO", Schema = "CRM")]
    public class replicaPedidos
    {
        [Key]
        public long? PEDI_COD_PEDIDO { get; set; }
        public string? PEDC_COD_TIPO_CANAL { get; set; }
        public string? PEDC_COD_TIPO_ESTADO { get; set; }
        public string? PEDC_COD_TIPO_MOTIVO_PEDIDO { get; set; }
        public long? PEDI_COD_CLIENTE { get; set; }
        public string? PEDC_NOMBRES_APELLIDOS { get; set; }
        public string? PEDC_COD_TIPO_DOC { get; set; }
        public string? PEDV_NUM_DOCUMENTO { get; set; }
        public string? PEDV_CORREO { get; set; }
        public string? PEDV_CELULAR { get; set; }
        public string? PEDV_OBSERVACIONES { get; set; }
        public long? PEDI_COD_DIRECCION { get; set; }
        public string? PEDC_NOM_NIVEL { get; set; }
        public string? PEDI_NRO_INMUEBLE { get; set; }
        public string? PEDC_UBIGEO { get; set; }
        public long? PEDI_COD_SERVICIO { get; set; }
        public Boolean? PEDB_POL_PRIV { get; set; }
        public Boolean? PEDB_TERM_COND { get; set; }
        public Boolean? PEDB_RECIBO_ELECTRONICO { get; set; }
        public int? PEDI_CUOTAS_INSTALACION { get; set; }
        public int? PEDI_CICLO_FACTURACION { get; set; }
        public DateTime? PEDD_FECHA_CIERRE { get; set; }
        public int? PEDI_NUM_INTENTO { get; set; }
        public string? PEDV_COD_VENDEDOR { get; set; }
        public int? PEDI_EST_REGISTRO { get; set; }
        public string? PEDV_USUARIO_CREACION { get; set; }
        public DateTime? PEDD_FECHA_CREACION { get; set; }
        public string? PEDV_USUARIO_ACTUALIZACION { get; set; }
        public DateTime? PEDD_FECHA_ACTUALIZACION { get; set; }
        public string? PEDV_NOMBRE_ADJUNTO { get; set; }
        public string? PEDV_APE_PATERNO { get; set; }
        public string? PEDV_APE_MATERNO { get; set; }
        public string? PEDC_COD_TIPO_REL_PREDIO { get; set; }
        public string? PEDC_COD_TIPO_SERIE { get; set; }
        public string? PEDV_NRO_CONTRATO { get; set; }
        public string? PEDV_CORREO2 { get; set; }
        public string? PEDV_TELEFONO { get; set; }
        public int? PEDI_CONT_WINTV { get; set; }
        public int? PEDI_COMP_WINSMART { get; set; }
        public int? PEDI_WINSMART_CUOTAS { get; set; }
        public int? PEDI_CANT_WINSMART { get; set; }
        public string? PEDV_NOMBRE_ADJUNTO_II { get; set; }
        public string? PEDV_TIPO_OT { get; set; }
        public long? PEDI_COD_PEDIDO_ANT { get; set; }
        public string? PEDC_COD_TIPO_MOTIVO_PEDIDO_HIJO { get; set; }
        public int? PEDI_TIPO_VENTA { get; set; }
        public string? PEDV_TIPO_VENTA_DETALLE { get; set; }
        public int? PEDI_COBERTURA { get; set; }
        public int? PEDI_WIFI_MESH { get; set; }
        public int? PEDI_CANT_WIFI { get; set; }
        public int? PEDI_CANT_WIFI_ADI { get; set; }
        public int? PEDI_CUOTAS_WIFI { get; set; }
        public int? ESTADO_CAMBIO_BANDEJA { get; set; }
        public int? PROCESO_MIGRACION { get; set; }
        public int? PEDI_DELIVERY { get; set; }
        public int? PEDI_INSTALACION_WIFI { get; set; }
        public string? PEDI_CANAL_VENTA { get; set; }
        public int? PEDI_VENDEDOR_REAL { get; set; }
        public int? PEDI_INSTALACION_CAMARA { get; set; }
        public long? PEDI_COD_CONTRATO_CRMEX { get; set; }
        public string? PEDI_MARCA_MESH { get; set; }
        public string? PEDI_RUC_EMPRESA { get; set; }
        public string? PEDI_RAZON_SOCIAL_EMPRESA { get; set; }
        public long? PEDI_TICKET_PEDIDO { get; set; }
        public long? OFTI_COD_OFERTA { get; set; }
        public string? PEDV_VENTA_ORIGEN { get; set; }
        public string? PEDV_COMO_SE_ENTERO { get; set; }
        public string? PEDV_S1 { get; set; }
        public int? PEDI_SCORE { get; set; }
        public int? PEDI_COD_VALIDADOR { get; set; }
        public string? PEDV_ESTADO_VALIDACION { get; set; }
        public string? PEDV_SUB_ESTADO_VALIDACION { get; set; }
        public string? PEDV_VENDEDOR_DOCUMENTO { get; set; }
        public string? PEDV_VENDEDOR_NOMBRE { get; set; }
        public int? PEDI_CODIGO_PEDIDO_REFERENCIA { get; set; }
        public int? PEDI_PORTABILIDAD { get; set; }
        public string? PEDV_NUMERO { get; set; }
        public int? PEDI_COD_CLIENTE_DIRECTV { get; set; }
        public int? PEDI_TIPO_ALTA_DTV { get; set; }
        public string? PEDV_OBSERVACION_VENTA { get; set; }
    }

    [Keyless]
    public class queryMensaje
    {
        public string? PEDC_COD_TIPO_ESTADO { get; set; }
        public string? PRGC_COD_TIPO_ESTADO { get; set; }
    }

}
