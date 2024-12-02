using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public class CM_Credito_materialesServices : ICM_Credito_materialesServices
    {


        public int Count()
        {
            try
            {
                return CM_Credito_materiales.Count();
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public List<CM_Credito_materiales> GetCreditoMPaginado(string buscarPor, string strParametro,
        int registro_desde, int registro_hasta)
        {
            try
            {
                return CM_Credito_materiales.GetCreditoMPaginado(buscarPor, strParametro,
                    registro_desde, registro_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}