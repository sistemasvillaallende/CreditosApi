using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public class BadecServices : IBadecServices
    {

        public List<BADEC>  GetDatosByCuit(string cuit){
            try
            {
                var lst = BADEC.GetBadecByCuit(cuit);
                return lst;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


    }
}