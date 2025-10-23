using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public class CM_rubro_creditoService : ICM_rubro_creditoService
    {


        public List<CM_rubro_credito> GetRubros(){
            try
            {
                var lst = CM_rubro_credito.read();
                return lst;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }


    }
}