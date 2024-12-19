using CreditosApi.Entities;
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;

namespace CreditosApi.Services
{
    public interface ICM_Ctasctes_credito_materialesServices
    {
        public CM_Detalle_deuda_credito_materiales GetDeuda(int nro_transaccion);
        public void InsertNuevaDeuda(Credito_CtasctesAuditoria obj);
        public void DeleteDeudaCtaCte(int tipo_transaccion, int nro_transaccion, Auditoria obj);
        public List<LstDeudaCredito> getListDeudaCredito(int id_credito_materiales);
        public List<LstDeudaCredito> GetListTodasDeudas(int id_credito_materiales);


    }
}