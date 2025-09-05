namespace CreditosApi.Entities.HELPERS
{
    public class Credito_materialesAuditoria
    {

        public CM_Credito_materiales creditoMateriales { get; set; }

        public int? categoria_deuda  { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }
        public Credito_materialesAuditoria()
        {
            creditoMateriales = new CM_Credito_materiales();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
