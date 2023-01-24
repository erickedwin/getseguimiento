using apixmlwin.Models;

namespace apixmlwin.Services
{
    public interface ISeguimiento
    {
      Task<pedidoResponse> getPedido(string numerodoc);
    }
}
