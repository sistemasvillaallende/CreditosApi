using CreditosApi.Entities;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CreditosApi.Services
{
    public class CM_UVAServices : ICM_UVAServices 
    {

        public List<CM_UVA> GetValorUva(){
        try
        {
                var binding = new BasicHttpBinding();
                var endpoint = new EndpointAddress("http://url-del-servicio/WSCedulones.asmx");

                var ws = new WSCedulones.CedulonesSoapClient(binding, endpoint);
                var respuesta = await ws.MetodoAsync("parametro");
                return CM_UVA.read();
        }
        catch (System.Exception)
        {
            throw;
        }
      }


    }
}