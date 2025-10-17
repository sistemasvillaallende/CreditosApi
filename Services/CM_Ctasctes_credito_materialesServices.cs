using System.Data.SqlClient;
using CreditosApi.Entities;
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;
using CreditosApi.Helpers;
using CreditosApi.Model;
using Newtonsoft.Json;

namespace CreditosApi.Services
{
    public class CM_ctasctes_credito_materialesService : ICM_Ctasctes_credito_materialesServices
    {

        public CM_Detalle_deuda_credito_materiales GetDeuda(int nro_transaccion)
        {
            try
            {
                return CM_Detalle_deuda_credito_materiales.getByPk(nro_transaccion);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void InsertNuevaDeuda(Credito_CtasctesAuditoria obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnection())
                {
                    con.Open();

                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            string string_detalle = "Se insertaron Deuda : ";
                            obj.auditoria.identificacion = obj.legajo.ToString();
                            obj.auditoria.proceso = "INSERTAR DEUDA CTACTE";
                            obj.auditoria.detalle = "";
                            obj.auditoria.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);

                            foreach (var item in obj.lstCtastes)
                            {
                                int ultimoRegistro = CM_Ctasctes_credito_materiales.ObtenerUltimoNroTransaccion(con, trx);
                                CM_Ctasctes_credito_materiales.Insert(item, con, trx, ultimoRegistro + 1);
                                string_detalle += JsonConvert.SerializeObject(CM_Ctasctes_credito_materiales.getByPk(item.tipo_transaccion, item.nro_transaccion));
                            }
                            obj.auditoria.detalle = string_detalle;
                            AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DeleteDeudaCtaCte(int tipo_transaccion, int nro_transaccion, Auditoria obj)
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnection())
                {
                    con.Open();

                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            obj.identificacion = "";
                            obj.proceso = "ELIMINAR DEUDA CTACTE";
                            obj.detalle = JsonConvert.SerializeObject(CM_Ctasctes_credito_materiales.getByPk(tipo_transaccion, nro_transaccion));
                            obj.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.CM_Ctasctes_credito_materiales.Delete(tipo_transaccion, nro_transaccion, con, trx);
                            AuditoriaD.InsertAuditoria(obj, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LstDeudaCredito> getListDeudaCredito(int id_credito_materiales)
        {
            try
            {
                var lst = LstDeudaCredito.getListDeudaCredito(id_credito_materiales);
                return lst;
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public List<LstDeudaCredito> GetListTodasDeudas(int id_credito_materiales)
        {
            try
            {
                var lst = LstDeudaCredito.GetListTodasDeudas(id_credito_materiales);
                return lst;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public List<CM_Ctasctes_credito_materiales> GetListCtaCteById(int id_credito_materiales)
        {
            try
            {
                var lst = CM_Ctasctes_credito_materiales.GetListCtaCteById(id_credito_materiales);
                return lst;

            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public List<ResumenImporteDTO> ResumenImporte()
        {
            try
            {
                return CM_Ctasctes_credito_materiales.ResumenImporte();
            }
            catch (System.Exception)
            {

                throw;
            }
        }


        public void ActualizarCreditos() // Auditoria obj
        {
            try
            {
                using (SqlConnection con = DALBase.GetConnection())
                {
                    con.Open();

                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            // obj.auditoria.identificacion = legajo.ToString();
                            // obj.auditoria.proceso = "ACTUALIZAR CUOTAS";
                            // obj.auditoria.detalle = JsonConvert.SerializeObject(obj.creditoMateriales);
                            // obj.auditoria.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);

                            //ActualizarCuotasUVATrimestral2(con, trx);
                            ActualizarCuotasUVATrimestral(con,trx);

                            // AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
                            trx.Commit();
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        //private int CalcularMesesEntre(DateTime fechaInicio, DateTime fechaFin)
        //{
        //    int meses = ((fechaFin.Year - fechaInicio.Year) * 12) + fechaFin.Month - fechaInicio.Month;

        //    // Si el día actual es menor al día de inicio, restamos un mes
        //    if (fechaFin.Day < fechaInicio.Day)
        //    {
        //        meses--;
        //    }

        //    return meses + 1; // +1 porque el primer mes cuenta como mes 1, no mes 0
        //}

        private int CalcularMesesEntre(DateTime fechaInicio, DateTime fechaFin)
        {
            int meses = ((fechaFin.Year - fechaInicio.Year) * 12) + fechaFin.Month - fechaInicio.Month;
            if (fechaFin.Day < fechaInicio.Day)
                meses--;
            return meses;
        }


        public void ActualizarCuotasUVATrimestral(SqlConnection con, SqlTransaction trx)
        {
            try
            {
                DateTime fechaActual = DateTime.Now;

                // Valor UVA actual
                Decimal valorUVAActual = CM_UVA.GetUltimaFila().valor_uva;

                // Traer todos los créditos
                var creditosTodos = CM_Credito_materiales.read(con, trx);

                foreach (var credito in creditosTodos)
                {
                    int idCredito = credito.id_credito_materiales;

                    // if (idCredito == 88)
                    // {
                        Decimal valorCuotaUVA = credito.valor_cuota_uva ?? 0;

                        // Traer las cuotas del crédito
                        var cuotas = CM_Ctasctes_credito_materiales.GetCuotasByCredito(idCredito, con, trx);
                        if (cuotas == null || cuotas.Count == 0)
                            continue;

                        // Tomar la fecha de la primera cuota (referencia real del trimestre)
                        DateTime fechaPrimeraCuota = cuotas.First().vencimiento;

                        // Calcular meses desde la PRIMERA cuota
                        int mesesDesdePrimeraCuota = CalcularMesesEntre(fechaPrimeraCuota, fechaActual);

                        // Solo actualizar si estamos en el inicio de un nuevo trimestre (0,3,6,9,...)
                        bool esInicioTrimestre = (mesesDesdePrimeraCuota % 3 == 0);

                        if (!esInicioTrimestre)
                            continue;

                        // Determinar trimestre actual
                        int trimestreActual = mesesDesdePrimeraCuota / 3;

                        // Calcular cuotas que pertenecen a este trimestre
                        int cuotaInicio = (trimestreActual * 3) + 1;
                        int cuotaFin = cuotaInicio + 2;

                        for (int i = cuotaInicio - 1; i <= cuotaFin - 1 && i < cuotas.Count; i++)
                        {
                            var cuota = cuotas[i];

                            // 🔒 Si la cuota está pagada, no se modifica
                            if (cuota.pagado == true)
                                continue;

                            Decimal montoPagado = cuota.monto_original - cuota.debe;
                            Decimal nuevoMontoPesos = valorCuotaUVA * valorUVAActual;

                            cuota.monto_original = nuevoMontoPesos;
                            cuota.debe = nuevoMontoPesos - montoPagado;

                            CM_Ctasctes_credito_materiales.Update(cuota, con, trx);
                        }
                    }
               // }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




    }
}