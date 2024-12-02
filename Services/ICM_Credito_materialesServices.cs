using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public interface ICM_Credito_materialesServices
    {
        public int Count();
        public List<CM_Credito_materiales> GetCreditoMPaginado(string buscarPor, string strParametro,
        int registro_desde, int registro_hasta);
    }
}