using CreditosApi.Entities.AUDITORIA;

namespace CreditosApi.Model
{
    public class CreditosModel
    {
        public int id_credito_materiales { get; set; }
        public int legajo { get; set; }
        public string domicilio { get; set; }
        public string cuit_solicitante { get; set; }
        public string nombre { get; set; }
        public string garantes { get; set; }
        public decimal presupuesto { get; set; }
        public int cant_cuotas { get; set; }
        public int circunscripcion { get; set; }
        public int seccion { get; set; }
        public int manzana { get; set; }
        public int parcela { get; set; }
        public int p_h { get; set; }
        public Auditoria auditoria { get; set; }



        public CreditosModel()
        {
            id_credito_materiales = 0;
            legajo = 0;
            domicilio = string.Empty;
            cuit_solicitante = string.Empty;
            nombre = string.Empty;
            garantes = string.Empty;
            presupuesto = 0;
            cant_cuotas = 0;
            circunscripcion = 0;
            seccion = 0;
            manzana = 0;
            parcela = 0;
            p_h = 0;
            auditoria = new Auditoria();

        }
    }
}
