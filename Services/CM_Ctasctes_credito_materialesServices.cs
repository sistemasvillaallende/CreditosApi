using CreditosApi.Entities;

namespace CreditosApi.Services
{
    public class CM_ctasctes_credito_materialesService : ICM_Ctasctes_credito_materialesServices
    {

            public CM_Detalle_deuda_credito_materiales GetDeuda(int nro_transaccion, int nro_item){
                try
                {
                    return CM_Detalle_deuda_credito_materiales.getByPk(nro_transaccion,nro_item);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

    }
}