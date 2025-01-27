using System.Data.SqlClient;
using CreditosApi.Entities;
using CreditosApi.Entities.AUDITORIA;
using CreditosApi.Entities.HELPERS;
using CreditosApi.Helpers;
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

        // public void InsertDeudasPorCuotas(CM_Credito_materiales obj, SqlConnection con, SqlTransaction trx)
        // {
        //     int cantCuotas = obj.cant_cuotas;
        //     Decimal presupuesto = obj.presupuesto;

        //     Decimal MontoXCuota = presupuesto / cantCuotas;

        //     for (int i = 0; i < cantCuotas; i++)
        //     {
        //         CM_Ctasctes_credito_materiales ctacte = new CM_Ctasctes_credito_materiales();
        //         ctacte.tipo_transaccion = 1;
        //         ctacte.fecha_trasaccion = DateTime.Now;
        //         ctacte.id_credito_materiales = obj.id_credito_materiales;
        //         ctacte.periodo = GeneradorPeriodo.GeneradorPeriodoXCuota(i);
        //         ctacte.monto_original = MontoXCuota;
        //         ctacte.debe = MontoXCuota;
        //         ctacte.vencimiento = DateTime.Now.AddMonths(1);

        //         int ultimoRegistro = CM_Ctasctes_credito_materiales.ObtenerUltimoNroTransaccion(con,trx);
        //         Entities.CM_Ctasctes_credito_materiales.Insert(ctacte,con,trx,ultimoRegistro);

        //     }
        // }

        // public void UpdateDeuda(int legajo, int id_credito_materiales, Credito_materialesAuditoria obj)
        // {
        //     try
        //     {
        //         using (SqlConnection con = DALBase.GetConnection())
        //         {
        //             con.Open();

        //             using (SqlTransaction trx = con.BeginTransaction())
        //             {
        //                 try
        //                 {
        //                     obj.auditoria.identificacion = legajo.ToString();
        //                     obj.auditoria.proceso = "ACTUALIZAR CREDITO MATERIALES";
        //                     obj.auditoria.detalle = JsonConvert.SerializeObject(obj.creditoMateriales);
        //                     obj.auditoria.observaciones = string.Format("Fecha auditoria: {0}", DateTime.Now);
        //                     Entities.CM_Credito_materiales.Update(legajo, id_credito_materiales, obj.creditoMateriales, con, trx);
        //                     AuditoriaD.InsertAuditoria(obj.auditoria, con, trx);
        //                     trx.Commit();
        //                 }
        //                 catch (Exception)
        //                 {
        //                     trx.Rollback();
        //                     throw;
        //                 }
        //             }
        //         }
        //     }

        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }




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


        public List<LstDeudaCredito> GetListTodasDeudas(int id_credito_materiales){
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


    }
}