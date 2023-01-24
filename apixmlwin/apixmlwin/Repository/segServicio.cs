using Microsoft.AspNetCore.Mvc;
using apixmlwin.Models;
using Microsoft.EntityFrameworkCore;
using apixmlwin.Context;
using System.Text.RegularExpressions;
using apixmlwin.Services;
using Microsoft.IdentityModel.Tokens;

namespace apixmlwin.Repository
{
    public class segServicio : ISeguimiento
    {
        private readonly crmwinContext _crm;
        private readonly awsEquifaxContext _lead;

        public segServicio(crmwinContext sco, awsEquifaxContext lea)
        {
            _crm = sco;
            _lead = lea;
        }
        
        public async Task<pedidoResponse> getPedido(string numerodoc)
        {
            pedidoResponse response = new pedidoResponse();

            try
            {
                if (string.IsNullOrEmpty(numerodoc))
                {
                    throw new NullReferenceException();
                }
                /* select a.PEDC_COD_TIPO_ESTADO , b.PRGC_COD_TIPO_ESTADO  
                  from CRM.CRM_PEDIDO a 
                  join CRM.CRM_PROGRAMACION b 
                  on a.PEDI_COD_CLIENTE = b.PRGI_COD_CLIENTE 
                  where a.PEDC_COD_TIPO_CANAL = 1 
                  and b.PRGC_COD_TIPO_MOTIVO_ESTADO = 32 
                  and a.PEDV_NUM_DOCUMENTO ={0}", dni*/


                var respuestaquery = await _crm.CRM_PEDIDO.Join(_crm.CRM_PROGRAMACION,
                    a => a.PEDI_COD_CLIENTE,
                    b => b.PRGI_COD_CLIENTE,
                    (a, b) => new { a, b })
                    .Where( x => //x.a.PEDC_COD_TIPO_CANAL == "1" && 
                    //x.b.PRGC_COD_TIPO_MOTIVO_ESTADO == "32" && 
                    x.a.PEDV_NUM_DOCUMENTO == numerodoc)
                    .Select(x => new
                    {
                        PEDC_COD_TIPO_ESTADO = x.a.PEDC_COD_TIPO_ESTADO,
                        PRGC_COD_TIPO_ESTADO = x.b.PRGC_COD_TIPO_ESTADO
                    })
                    .FirstOrDefaultAsync();


                if (respuestaquery == null)
                {
                    response.Mensaje = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56F").Result.regla;
                    response.Error = true;
                    response.Data = null;
                    return response;
                }
                
                switch ((respuestaquery.PEDC_COD_TIPO_ESTADO, respuestaquery.PRGC_COD_TIPO_ESTADO))
                {
                    //prueba 1 valor encontrado
                    case ("02", "05"):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                        break;
                    // prueba 2 con valor nulo
                    case ("04", null):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56B").Result.regla;
                        break;

                    case ("02", null):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                        break;

                    case ("05", null):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                        break;

                    case ("03",null):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56B").Result.regla;
                        break;

                    case ("11", null):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                        break;

                    case ("02","01"):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                        break;

                    case ("02","02"):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56C").Result.regla;
                        break;

                    case ("06", "02"):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56B").Result.regla;
                        break;

                    case ("02", "06"):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56B").Result.regla;
                        break;

                    case ("02", "04"):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56C").Result.regla;
                        break;

                    case ("02", "03"):
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56D").Result.regla;
                        break;

                    default:
                        response.Mensaje = "Sin errores";
                        response.Error = false;
                        response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56E").Result.regla;
                        break;

                }
                /*
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "04" && respuestaquery.PRGC_COD_TIPO_ESTADO.IsNullOrEmpty())
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56C").Result.regla;

                }

                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "02" && respuestaquery.PRGC_COD_TIPO_ESTADO.IsNullOrEmpty())
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                    
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "05" && respuestaquery.PRGC_COD_TIPO_ESTADO.IsNullOrEmpty())
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                    
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "03" && respuestaquery.PRGC_COD_TIPO_ESTADO == "")
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56B").Result.regla;
                    
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "11" && respuestaquery.PRGC_COD_TIPO_ESTADO.IsNullOrEmpty())
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                   
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "02" && respuestaquery.PRGC_COD_TIPO_ESTADO == "01")
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56A").Result.regla;
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "02" && respuestaquery.PRGC_COD_TIPO_ESTADO == "02")
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56C").Result.regla;
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "06" && respuestaquery.PRGC_COD_TIPO_ESTADO == "02")
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56B").Result.regla;
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "02" && respuestaquery.PRGC_COD_TIPO_ESTADO == "06")
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56B").Result.regla;
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "02" && respuestaquery.PRGC_COD_TIPO_ESTADO == "04")
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56C").Result.regla;
                }
                if (respuestaquery.PEDC_COD_TIPO_ESTADO == "02" && respuestaquery.PRGC_COD_TIPO_ESTADO == "03")
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56D").Result.regla;
                }
                else
                {
                    response.Mensaje = "Sin errores";
                    response.Error = false;
                    response.Data = _lead.t_reglas.FirstOrDefaultAsync(x => x.codigo == "RF56E").Result.regla;
                }*/
                return response;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.Error = true;
                response.Data = null;
                return response;
                //return Task.FromResult(response);

            }


        }
    }
}
