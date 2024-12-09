namespace CreditosApi.Entities.HELPERS
{
    public class Credito_CtasctesAuditoria
    {
        public int legajo { get; set; }
        public List<CM_Ctasctes_credito_materiales> lstCtastes { get; set; }
        public AUDITORIA.Auditoria auditoria { get; set; }
        public Credito_CtasctesAuditoria()
        {
            legajo = 0;
            lstCtastes = new List<CM_Ctasctes_credito_materiales>();
            auditoria = new AUDITORIA.Auditoria();
        }
    }
}
