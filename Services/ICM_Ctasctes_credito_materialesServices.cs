using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public interface ICM_Ctasctes_credito_materialesServices
    {
        public CM_Detalle_deuda_credito_materiales GetDeuda(int nro_transaccion, int nro_item);

    }
}