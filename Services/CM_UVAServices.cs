using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public class CM_UVAServices : ICM_UVAServices 
    {

      public List<CM_UVA> GetValorUva(){
        try
        {
            return CM_UVA.read();
        }
        catch (System.Exception)
        {
            throw;
        }
      }


    }
}