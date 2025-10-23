using CreditosApi.Entities.AUDITORIA;

namespace CreditosApi.Model
{
    public class ResumenImporteDTO
    {

        public int id_credito_materiales { get; set; }
        public int legajo { get; set; }
        public DateTime fecha_alta { get; set; }
        public string cuit_solicitante { get; set; }
        public string domicilio { get; set; }
        public string nombre { get; set; }
        public decimal presupuesto { get; set; }
        public int cant_cuotas { get; set; }
        public decimal imp_pagado { get; set; }
        public decimal imp_adeudado { get; set; }
        public decimal imp_vencido { get; set; }
        public int cuotas_vencidas { get; set; }
        public int cuotas_pagadas { get; set; }
        public string fecha_ultimo_pago { get; set; }

        public ResumenImporteDTO()
        {
            id_credito_materiales = 0;
            legajo = 0;
            fecha_alta = DateTime.Now;
            cuit_solicitante = string.Empty;
            domicilio = string.Empty;
            nombre = string.Empty;
            presupuesto = 0;
            cant_cuotas = 0;
            imp_pagado = 0;
            imp_adeudado = 0;
            imp_vencido = 0;
            cuotas_vencidas = 0;
            cuotas_pagadas = 0;
            fecha_ultimo_pago = string.Empty;      
        }
    }
}
