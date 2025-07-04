using System.Data.SqlClient;
using System.Globalization;
using CreditosApi.Entities;
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;
using CreditosApi.Helpers;
using Newtonsoft.Json;

namespace CreditosApi.Services
{
    public class CM_Credito_materialesServices : ICM_Credito_materialesServices
    {



        public CM_Credito_materiales GetCreditoById(int id_credito_materiales)
        {
            try
            {
                return CM_Credito_materiales.GetById(id_credito_materiales);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // public List<CM_Credito_materiales> GetAllCreditos()
        // {
        //     try
        //     {
        //         List<CM_Credito_materiales> allCreditos = CM_Credito_materiales.read();


        //         foreach (var cred in allCreditos)
        //         {
        //             List<LstDeudaCredito> allDeudas = LstDeudaCredito.getListDeudaCredito(cred.id_credito_materiales);

        //             foreach (var deuda in allDeudas)
        //             {
        //                 decimal totalVencido = 0;

        //                 if (DateTime.TryParseExact(deuda.fecha_vencimiento, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaVenc))
        //                 {
        //                     if (fechaVenc < DateTime.Today)
        //                     {
        //                         // cred.con_deuda = 1;
        //                         // cred.saldo_adeudado = deuda.importe;
        //                         // break;
        //                         totalVencido += deuda.importe;
        //                     }
        //                 }
        //             }

        //         }

        //         return allCreditos;
        //     }
        //     catch (System.Exception)
        //     {

        //         throw;
        //     }
        // }
        public List<CM_Credito_materiales> GetAllCreditos()
        {
            try
            {
                List<CM_Credito_materiales> allCreditos = CM_Credito_materiales.read();

                foreach (var cred in allCreditos)
                {
                    List<LstDeudaCredito> allDeudas = LstDeudaCredito.getListDeudaCredito(cred.id_credito_materiales);

                    decimal totalVencido = 0;

                    foreach (var deuda in allDeudas)
                    {
                        if (DateTime.TryParseExact(deuda.fecha_vencimiento, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaVenc))
                        {
                            if (fechaVenc < DateTime.Today)
                            {
                                totalVencido += deuda.importe;
                            }
                        }
                    }

                    if (totalVencido > 0)
                    {
                        cred.con_deuda = 1;
                        cred.saldo_adeudado = totalVencido;
                    }
                }

                return allCreditos;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public int Count()
        {
            try
            {
                return CM_Credito_materiales.Count();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<CM_Credito_materiales> GetCreditoMPaginado(string buscarPor, string? strParametro,
        int registro_desde, int registro_hasta)
        {
            try
            {
                return CM_Credito_materiales.GetCreditoMPaginado(buscarPor, strParametro,
                    registro_desde, registro_hasta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertNuevoCredito(Credito_materialesAuditoria obj)
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
                            var objCM = obj.creditoMateriales;

                            obj.auditoria.identificacion = objCM.legajo.ToString();
                            obj.auditoria.proceso = "NUEVO CREDITO MATERIALES";
                            obj.auditoria.detalle = JsonConvert.SerializeObject(obj.creditoMateriales);
                            obj.auditoria.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);

                            objCM.presupuesto_uva = CalculoPresupuestoUVA(objCM.presupuesto);
                            objCM.valor_cuota_uva = ValorCuotaUVA(objCM.presupuesto_uva, objCM.cant_cuotas);

                            int idCredito = Entities.CM_Credito_materiales.Insert(objCM, con, trx);
                            InsertDeudasPorCuotas(objCM, idCredito, con, trx);
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

        public void UpdateCredito(int legajo, int id_credito_materiales, Credito_materialesAuditoria obj)
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
                            obj.auditoria.identificacion = legajo.ToString();
                            obj.auditoria.proceso = "ACTUALIZAR CREDITO MATERIALES";
                            obj.auditoria.detalle = JsonConvert.SerializeObject(obj.creditoMateriales);
                            obj.auditoria.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);

                            CM_Credito_materiales creditoActual = CM_Credito_materiales.getByPk(id_credito_materiales, legajo); // Sacando legajo 

                            // Actualiza los datos actuales del credito 
                            Entities.CM_Credito_materiales.Update(legajo, id_credito_materiales, obj.creditoMateriales, con, trx);

                            UpdateCtaCtesXCredito(creditoActual, obj.creditoMateriales.cant_cuotas, obj.creditoMateriales.presupuesto, con, trx);

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

        public void BajaCredito(int legajo, int id_credito_materiales, Auditoria obj)
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
                            obj.identificacion = legajo.ToString();
                            obj.proceso = "BAJA CREDITO MATERIALES";
                            obj.detalle = JsonConvert.SerializeObject(CM_Credito_materiales.getByPk(id_credito_materiales, legajo));
                            obj.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.CM_Credito_materiales.BajaCredito(legajo, id_credito_materiales, con, trx);
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

        public void AltaCredito(int id_credito_materiales, Auditoria obj)
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
                            obj.identificacion = id_credito_materiales.ToString();
                            obj.proceso = "ALTA CREDITO MATERIALES";
                            // obj.detalle = JsonConvert.SerializeObject(CM_Credito_materiales.getByPk(id_credito_materiales, legajo));
                            obj.detalle = "";
                            obj.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.CM_Credito_materiales.AltaCredito(id_credito_materiales, con, trx);
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

        public void DeleteCredito(int legajo, int id_credito_materiales, Auditoria obj)
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
                            obj.identificacion = legajo.ToString();
                            obj.proceso = "ELIMINAR CREDITO MATERIALES";
                            obj.detalle = JsonConvert.SerializeObject(CM_Credito_materiales.getByPk(id_credito_materiales, legajo));
                            obj.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);
                            Entities.CM_Credito_materiales.Delete(legajo, id_credito_materiales, con, trx);
                            EliminarCtaCtesXCredito(id_credito_materiales, con, trx);

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

        //nro_transaccion = GetNroTransaccion(4, con, trx);
        //UpdateNroTransaccion(4, (nro_transaccion + lst.Count), con, trx);

        public void InsertDeudasPorCuotas(CM_Credito_materiales obj, int idCredito, SqlConnection con, SqlTransaction trx)
        {
            int cantCuotas = obj.cant_cuotas;
            Decimal presupuesto = obj.presupuesto;
            Decimal MontoXCuota = Math.Ceiling(presupuesto / cantCuotas); // Ceiling y floor
            int aux_nrotransaccion = CM_Ctasctes_credito_materiales.ObtenerUltimoNroTransaccion(con, trx);
            //
            for (int i = 0; i < cantCuotas; i++)
            {
                aux_nrotransaccion += 1;
                CM_Ctasctes_credito_materiales ctacte = new CM_Ctasctes_credito_materiales();
                ctacte.tipo_transaccion = 1;
                ctacte.fecha_trasaccion = DateTime.Now;
                ctacte.id_credito_materiales = idCredito;
                //ctacte.periodo = GeneradorPeriodo.GeneradorPeriodoXCuota(i);
                ctacte.periodo = GeneradorPeriodo.GeneradorCuotaxCantidad(i, cantCuotas);
                ctacte.monto_original = MontoXCuota; // aca en UVA con el primer valor del UVA
                ctacte.debe = MontoXCuota; /// Y Este ya en pesos ?
                ctacte.categoria_deuda = 1; // Por ahora lo hardcodeo, despeus lo mando por params
                ctacte.vencimiento = DateTime.Now.AddMonths(i + 1);
                //
                //int ultimoRegistro = CM_Ctasctes_credito_materiales.ObtenerUltimoNroTransaccion(con, trx);
                CM_Ctasctes_credito_materiales.Insert(ctacte, con, trx, aux_nrotransaccion);
            }
        }


        public void EliminarCtaCtesXCredito(int id_credito_materiales, SqlConnection con, SqlTransaction trx)
        {

            List<CM_Ctasctes_credito_materiales> lst = CM_Ctasctes_credito_materiales.GetListCtaCteById(id_credito_materiales, con, trx);

            foreach (var item in lst)
            {
                if (item.pagado == false)
                {
                    CM_Ctasctes_credito_materiales.Delete(item.tipo_transaccion, item.nro_transaccion, con, trx);
                }
            }

        }

        public void UpdateCtaCtesXCredito(CM_Credito_materiales creditoActual, int cuotasNvas, decimal presupuestoNvo, SqlConnection con, SqlTransaction trx)
        {

            List<CM_Ctasctes_credito_materiales> cuotasActuales = CM_Ctasctes_credito_materiales.GetListCtaCteById(creditoActual.id_credito_materiales, con, trx);
            decimal montoPorCuotaNuevo = Math.Ceiling(presupuestoNvo / cuotasNvas);


            if (cuotasNvas > cuotasActuales.Count())
            {
                for (int i = cuotasActuales.Count(); i < cuotasNvas; i++)
                {
                    CM_Ctasctes_credito_materiales nuevaCuota = new CM_Ctasctes_credito_materiales
                    {
                        tipo_transaccion = 1,
                        fecha_trasaccion = DateTime.Now,
                        id_credito_materiales = creditoActual.id_credito_materiales,
                        periodo = GeneradorPeriodo.GeneradorPeriodoXCuota(i),
                        monto_original = montoPorCuotaNuevo,
                        debe = montoPorCuotaNuevo,
                        categoria_deuda = 1,
                        vencimiento = DateTime.Now.AddMonths(i + 1)
                    };

                    int ultimoRegistro = CM_Ctasctes_credito_materiales.ObtenerUltimoNroTransaccion(con, trx);
                    Entities.CM_Ctasctes_credito_materiales.Insert(nuevaCuota, con, trx, ultimoRegistro + 1);
                }
            }
            else if (cuotasNvas < cuotasActuales.Count())
            {
                Entities.CM_Ctasctes_credito_materiales.DeleteExcedente(creditoActual.id_credito_materiales, cuotasNvas, con, trx);
                cuotasActuales = CM_Ctasctes_credito_materiales.GetListCtaCteById(creditoActual.id_credito_materiales, con, trx);

            }

            foreach (var cuota in cuotasActuales)
            {
                cuota.monto_original = montoPorCuotaNuevo;
                cuota.debe = montoPorCuotaNuevo;
                Entities.CM_Ctasctes_credito_materiales.Update(cuota, con, trx);
            }


        }

        // Setter presupuesto Uva, es decir, del presupuesto total lo divido por el monto del valor del uva actual

        // setter en valor de cuota uva, es del anterior dividirlo por la cantidad de cuotas 

        // PRESUPUESTO UVA INICIAL
        public decimal CalculoPresupuestoUVA(decimal presupuesto)
        {

            decimal valor_uva = CM_UVA.GetUltimaFila().valor_uva;
            decimal presupuesto_uva = presupuesto / valor_uva;

            return presupuesto_uva;
        }

        // Para settear al valor de la cuota UVA
        public decimal ValorCuotaUVA(decimal presupuesto_uva, int cant_cuotas)
        {

            return presupuesto_uva / cant_cuotas;
        }

        // Agarras la deuda cuota de UVA (en UVAS) y la multiplicas por el monto de la unidad del uva para obtener lo que se debe

        public decimal MontoCuotaUva(decimal valor_cuota_uva)
        {

            decimal valor_uva = CM_UVA.GetUltimaFila().valor_uva;
            return valor_cuota_uva * valor_uva;

        }

    }
}