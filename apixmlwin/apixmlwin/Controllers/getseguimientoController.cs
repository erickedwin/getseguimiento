using Microsoft.AspNetCore.Mvc;
using apixmlwin.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using apixmlwin.Services;
using apixmlwin.Repository;
using apixmlwin.Context;

namespace apixmlwin.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class getseguimientoController : ControllerBase
    {
        /*private readonly crmwinContext _crm;
        private readonly awsEquifaxContext _lead;

        public seguimiento(crmwinContext sco, awsEquifaxContext lea)
        {
            _crm = sco;
            _lead = lea;
        }*/
        private readonly ISeguimiento _iservicio; 

         public getseguimientoController(ISeguimiento segui)
         {
             _iservicio = segui;
         }



        [HttpGet("{numdoc}")]
        
        public async Task<IActionResult> getEstadoPedido(string? numdoc)
        {
            pedidoResponse response= new pedidoResponse();
            try
            {
                response = await _iservicio.getPedido(numdoc);
                if (!response.Error)
                {
                    return StatusCode(StatusCodes.Status200OK, response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, response);
                }
            }
            catch(Exception ex)
            {
                response.Error = true;
                response.Mensaje = ex.Message;
                response.Data = null;
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
