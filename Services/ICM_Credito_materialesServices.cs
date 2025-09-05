using System.Data.SqlClient;
using CreditosApi.Entities;
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;

namespace CreditosApi.Services
{
    public interface ICM_Credito_materialesServices
    {
        public  List<CM_Credito_materiales> GetAllCreditos();
        public  List<CM_Credito_materiales> GetAllCreditos(SqlConnection con, SqlTransaction trx);
        public CM_Credito_materiales GetCreditoById(int id_credito_materiales);
        public List<CM_Credito_materiales> GetCreditoById(int id_credito_materiales, SqlConnection con, SqlTransaction trx);
        public int Count();
        public List<CM_Credito_materiales> GetCreditoMPaginado(string buscarPor, string? strParametro,
        int registro_desde, int registro_hasta);

        public void InsertNuevoCredito(Credito_materialesAuditoria obj);
        public void UpdateCredito(int legajo, int id_credito_materiales, Credito_materialesAuditoria obj);
        public void DeleteCredito(int legajo, int id_credito_materiales, Auditoria obj);
        public void BajaCredito(int legajo, int id_credito_materiales, Auditoria obj);
        public void AltaCredito( int id_credito_materiales, Auditoria obj);

    }
}